using System.IO;
using MeltySynth;
using UnityEngine;

namespace HGS.Tone
{
  public class ToneSequencer : MonoBehaviour
  {
    [SerializeField] string midiFile = "file";
    [SerializeField] string soundFontFile = "GeneralUserGS";
    [SerializeField] bool isLoop = false;
    Synthesizer _synthesizer;
    MidiFileSequencer _sequencer;

    void Start()
    {
      CreateSynth();
      CreateAudioSource();
      LoadFile();
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
      _sequencer = new MidiFileSequencer(_synthesizer);
    }

    void LoadFile()
    {
      var asset = Resources.Load<TextAsset>(midiFile);
      var stream = new MemoryStream(asset.bytes);
      var midi = new MidiFile(stream);
      _sequencer.Play(midi, isLoop);
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
      var dataLen = data.Length / channels;

      var sample = new float[data.Length];
      var right = new float[dataLen];

      _sequencer.RenderInterleaved(sample);

      sample.CopyTo(data, 0);
    }
  }
}