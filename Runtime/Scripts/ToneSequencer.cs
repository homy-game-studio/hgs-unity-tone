using System.IO;
using MeltySynth;
using UnityEngine;
using static MeltySynth.Synthesizer;

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

    public OnMidiMessage onMidiMessage;

    void Awake()
    {
      CreateSynth();
      CreateDriver();
    }

    void CreateSynth()
    {
      _synthesizer = new Synthesizer(soundFont.SoundFont, AudioSettings.outputSampleRate);
      _synthesizer.onMidiMessage = onMidiMessage;
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

    public void SetInstrument(int channel, int number)
    {
      _synthesizer.ProcessMidiMessage(channel, 0xC0, number, 0);
    }

    public void SetInstrument(int channel, MidiInstrumentCode instrumentCode)
    {
      SetInstrument(channel, (int)instrumentCode);
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