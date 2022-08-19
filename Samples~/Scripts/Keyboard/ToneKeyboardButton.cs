using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HGS.Tone.KeyboardSample
{
  public class ToneKeyboardButton : MonoBehaviour, IPointerDownHandler
  {
    [SerializeField] KeyCode keyCode;
    [SerializeField] float pressureLevel = 0.5f;
    [SerializeField] float colorSpeed = 0.5f;
    [SerializeField] float pressureSpeed = 10;
    [SerializeField] AudioSource btnAudio;

    [SerializeField] Renderer objRenderer = null;
    [SerializeField] Color triggedColor = Color.black;

    Color _startColor;
    Color _currentColor;

    Vector3 _startLocalPos;
    Vector3 _triggedPos;
    Vector3 _currentPosition;

    public Action onTrigger = null;

    void Start()
    {
      //  Color
      _startColor = objRenderer.material.color;
      _currentColor = _startColor;

      // Pressure
      _startLocalPos = transform.localPosition;

      _triggedPos = _startLocalPos;
      _triggedPos.y -= pressureLevel;

      _currentPosition = _startLocalPos;
    }

    void Update()
    {
      if (Input.GetKeyDown(keyCode)) Trigger();

      transform.localPosition = Vector3.Lerp(transform.localPosition, _currentPosition, Time.deltaTime * pressureSpeed);
      objRenderer.material.color = Color.Lerp(objRenderer.material.color, _currentColor, Time.deltaTime * colorSpeed);
    }

    private void Release()
    {
      _currentPosition = _startLocalPos;
      _currentColor = _startColor;
    }

    private void Trigger()
    {
      onTrigger?.Invoke();
      _currentPosition = _triggedPos;
      _currentColor = triggedColor;
      btnAudio.Play();

      Invoke(nameof(Release), 0.1f);
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