using System.Collections.Generic;
using UnityEngine;

namespace HGS.Tone.KeyboardSample
{
  public class CameraTake : MonoBehaviour
  {
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float rotateSeed = 20f;
    [SerializeField] int initialTake = 1;
    [SerializeField] List<Transform> takes = new List<Transform>();

    Vector3 _currentPosition = Vector3.zero;
    Quaternion _currentRotation = Quaternion.identity;

    int _currentTake = 0;

    void Awake()
    {
      _currentPosition = transform.position;
      _currentRotation = transform.rotation;
    }

    void Start()
    {
      SetTake(initialTake);
    }

    void Update()
    {
      transform.position = Vector3.Lerp(transform.position, _currentPosition, Time.deltaTime * moveSpeed);
      transform.rotation = Quaternion.Lerp(transform.rotation, _currentRotation, Time.deltaTime * rotateSeed);

      if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
      {
        _currentTake++;
        if (_currentTake > takes.Count - 1) _currentTake = 0;
        SetTake(_currentTake);
      }
    }

    public void SetTake(int id)
    {
      _currentTake = id;
      _currentPosition = takes[id].position;
      _currentRotation = takes[id].rotation;
    }
  }
}