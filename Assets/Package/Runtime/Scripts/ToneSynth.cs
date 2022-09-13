using System.Collections;
using MeltySynth;
using UnityEngine;
using static MeltySynth.Synthesizer;

namespace HGS.Tone
{
  public class ToneSynth : MonoBehaviour
  {
    [SerializeField] ToneSoundFont soundFont = null;
    [SerializeField] int instrumentId = 0;
    [SerializeField] bool loadOnStart = false;

    Synthesizer _synthesizer;

    public OnMidiMessage onMidiMessage;

    void Awake()
    {
      if (loadOnStart) Load();
    }

    public void Load()
    {
      CreateSynth();
      CreateDriver();
      SetInstrument(instrumentId);
    }

    public void TriggerAttack(ToneNote note, int velocity = 100)
    {
      _synthesizer.NoteOn(0, note.Semitones, velocity);
    }

    public void TriggerRelease(ToneNote note)
    {
      _synthesizer.NoteOff(0, note.Semitones);
    }

    public void TriggerAttackAndRelease(ToneNote note, int velocity = 100, float duration = 0.15f)
    {
      StartCoroutine(TriggerAttackAndReleaseCoroutine(note, velocity, duration));
    }

    private IEnumerator TriggerAttackAndReleaseCoroutine(ToneNote note, int velocity, float duration)
    {
      TriggerAttack(note, velocity);
      yield return new WaitForSeconds(duration);
      TriggerRelease(note);
    }

    public void TriggerReleaseAll(bool immediate = false)
    {
      _synthesizer.NoteOffAll(immediate);
    }

    void CreateSynth()
    {
      _synthesizer = new Synthesizer(soundFont.SoundFont, AudioSettings.outputSampleRate);
      _synthesizer.onMidiMessage = onMidiMessage;
    }

    void CreateDriver()
    {
      var driver = gameObject.GetComponent<ToneAudioDriver>();
      if (driver == null) driver = gameObject.AddComponent<ToneAudioDriver>();

      driver.SetRenderer(_synthesizer);
    }

    public void SetInstrument(MidiInstrumentCode code)
    {
      SetInstrument((int)code);
    }

    public void SetInstrument(int id)
    {
      _synthesizer.ProcessMidiMessage(0, 0xC0, id, 0);
    }
  }
}