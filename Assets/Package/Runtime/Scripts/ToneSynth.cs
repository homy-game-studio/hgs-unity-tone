using System.IO;
using MeltySynth;
using UnityEngine;

namespace HGS.Tone
{
  public class ToneSynth : MonoBehaviour
  {
    [SerializeField] string soundFontFile = "GeneralUserGS";
    [SerializeField] int instrumentId = 0;
    Synthesizer _synthesizer;

    void Start()
    {
      CreateSynth();
      SetInstrument(instrumentId);
      CreateAudioSource();
    }

    public void TriggerAttack(ToneNote note, int velocity = 100)
    {
      _synthesizer.NoteOn(0, note.Key, velocity);
    }

    public void TriggerRelease(ToneNote note)
    {
      _synthesizer.NoteOff(0, note.Key);
    }

    void CreateAudioSource()
    {
      if (!gameObject.TryGetComponent(out AudioSource source))
      {
        gameObject.AddComponent<AudioSource>();
      }
    }

    void CreateSynth()
    {
      var asset = Resources.Load<TextAsset>(soundFontFile);
      var stream = new MemoryStream(asset.bytes);
      var soundFont = new SoundFont(stream);

      _synthesizer = new Synthesizer(soundFont, AudioSettings.outputSampleRate);
    }

    void SetInstrument(int id)
    {
      _synthesizer.ProcessMidiMessage(0, 0xC0, id, 0);
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
      var dataLen = data.Length / channels;

      var sample = new float[data.Length];
      var right = new float[dataLen];

      _synthesizer.RenderInterleaved(sample);

      sample.CopyTo(data, 0);
    }
  }
}