using MeltySynth;
using UnityEngine;

namespace HGS.Tone
{
  public class ToneAudioDriver : MonoBehaviour
  {
    IAudioRenderer _audioRenderer;
    float[] _buffer;

    void Awake()
    {
      CreateAudioSource();
    }

    void CreateAudioSource()
    {
      if (!gameObject.TryGetComponent(out AudioSource source))
      {
        gameObject.AddComponent<AudioSource>();
      }
    }

    public void SetRenderer(IAudioRenderer audioRenderer)
    {
      _audioRenderer = audioRenderer;
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
      _buffer = new float[data.Length];
      _audioRenderer.RenderInterleaved(_buffer);
      _buffer.CopyTo(data, 0);
    }
  }
}