using System.IO;
using MeltySynth;
using UnityEngine;

namespace HGS.Tone
{
  public class ToneSequencer : MonoBehaviour
  {
    [SerializeField] ToneSoundFont soundFont = null;
    [SerializeField] bool isLoop = false;
    Synthesizer _synthesizer;
    MidiFileSequencer _sequencer;

    bool _isPlaying = false;

    bool IsPlaying => _isPlaying;

    void Start()
    {
      CreateSynth();
      CreateDriver();
    }

    void CreateSynth()
    {
      _synthesizer = new Synthesizer(soundFont.SoundFont, AudioSettings.outputSampleRate);
      _sequencer = new MidiFileSequencer(_synthesizer);
    }

    public void Play(string file)
    {
      var asset = Resources.Load<TextAsset>(file);
      var stream = new MemoryStream(asset.bytes);
      Play(stream);
    }

    public void Play(Stream stream)
    {
      _sequencer.Stop();
      var midi = new MidiFile(stream);
      _sequencer.Play(midi, isLoop);
      _isPlaying = true;
    }

    public void Stop()
    {
      _sequencer.Stop();
      _isPlaying = false;
    }

    void CreateDriver()
    {
      var driver = gameObject.GetComponent<ToneAudioDriver>();
      if (driver == null) driver = gameObject.AddComponent<ToneAudioDriver>();

      driver.SetRenderer(_sequencer);
    }
  }
}