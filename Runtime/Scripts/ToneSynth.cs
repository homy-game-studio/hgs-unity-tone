using MeltySynth;
using UnityEngine;

namespace HGS.Tone
{
  public class ToneSynth : MonoBehaviour
  {
    [SerializeField] ToneSoundFont soundFont = null;
    [SerializeField] int instrumentId = 0;

    Synthesizer _synthesizer;

    void Start()
    {
      CreateSynth();
      CreateDriver();
      SetInstrument(instrumentId);
    }

    public void TriggerAttack(ToneNote note, int velocity = 100)
    {
      _synthesizer.NoteOn(0, note.Key, velocity);
    }

    public void TriggerRelease(ToneNote note)
    {
      _synthesizer.NoteOff(0, note.Key);
    }

    void CreateSynth()
    {
      _synthesizer = new Synthesizer(soundFont.SoundFont, AudioSettings.outputSampleRate);
    }

    void CreateDriver()
    {
      var driver = gameObject.GetComponent<ToneAudioDriver>();
      if (driver == null) driver = gameObject.AddComponent<ToneAudioDriver>();

      driver.SetRenderer(_synthesizer);
    }

    void SetInstrument(int id)
    {
      _synthesizer.ProcessMidiMessage(0, 0xC0, id, 0);
    }
  }
}