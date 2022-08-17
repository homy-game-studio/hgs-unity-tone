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
      CreateDriver();
      LoadFile();
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

    void CreateDriver()
    {
      var driver = gameObject.GetComponent<ToneAudioDriver>();
      if (driver == null) driver = gameObject.AddComponent<ToneAudioDriver>();

      driver.SetRenderer(_sequencer);
    }
  }
}