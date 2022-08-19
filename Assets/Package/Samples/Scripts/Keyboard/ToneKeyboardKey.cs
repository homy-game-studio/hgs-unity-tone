using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HGS.Tone.KeyboardSample
{
  public class ToneKeyboardKey : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
  {
    [SerializeField] KeyCode keyCode = 0;
    [SerializeField] int keyId = 0;
    [SerializeField] float angle = 15;
    [SerializeField] float angleSpeed = 10;

    Quaternion _releasedRotation;
    Quaternion _triggedRotation;
    Quaternion _currentRotation;

    public Action<int> onTrigger = null;
    public Action<int> onRelease = null;

    void Start()
    {
      _releasedRotation = transform.rotation;
      _triggedRotation = transform.rotation * Quaternion.AngleAxis(angle, transform.forward);
      _currentRotation = _releasedRotation;
    }

    void Update()
    {
      if (Input.GetKeyDown(keyCode)) Trigger();
      if (Input.GetKeyUp(keyCode)) Release();

      transform.rotation = Quaternion.Lerp(transform.rotation, _currentRotation, Time.deltaTime * angleSpeed);
    }

    private void Release()
    {
      onRelease?.Invoke(keyId);
      _currentRotation = _releasedRotation;
    }

    private void Trigger()
    {
      onTrigger?.Invoke(keyId);
      _currentRotation = _triggedRotation;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
      Trigger();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
      Release();
    }
  }
}