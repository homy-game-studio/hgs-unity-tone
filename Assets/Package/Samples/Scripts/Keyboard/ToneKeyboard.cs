using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace HGS.Tone.KeyboardSample
{
  public class ToneKeyboard : MonoBehaviour
  {
    [SerializeField] ToneKeyboardDisplayPanel menuPanel = null;
    [SerializeField] List<ToneKeyboardDisplayPanel> allPanels = null;
    [SerializeField] ToneKeyboardButton powerButton = null;
    [SerializeField] ToneSynth toneSynth = null;
    [SerializeField] ToneSequencer toneSequencer = null;
    [SerializeField] ToneKeyboardInstrument instrumentSelector = null;
    [SerializeField] ToneKeyboardMidi MidiSelector = null;
    [SerializeField] ToneKeyboardOctave octaveSelector = null;
    [SerializeField] List<ToneKeyboardKey> keys = new List<ToneKeyboardKey>();

    bool _isActive = false;

    void Awake()
    {
      powerButton.onTrigger += HandlePowerButtonTrigger;
      instrumentSelector.onChange += HandleOnChangeInstrument;
      MidiSelector.onTrigger += HandleOnMidiTrigger;
      keys.ForEach(key =>
      {
        key.onTrigger += HandleOnKeyTrigger;
        key.onRelease += HandleOnKeyRelease;
      });
    }

    private void HandleOnMidiTrigger(TextAsset obj)
    {
      if (obj == null)
      {
        toneSequencer.Stop();
      }
      else
      {
        var stream = new MemoryStream(obj.bytes);
        toneSequencer.Play(stream);
      }
    }

    private void HandlePowerButtonTrigger()
    {
      toneSynth.Load();
      _isActive = !_isActive;

      if (!_isActive)
      {
        toneSequencer.Stop();
        toneSynth.TriggerReleaseAll();
        allPanels.ForEach(panel => panel.Hide());
      }
      else
      {
        menuPanel.Show();
      }
    }

    void HandleOnChangeInstrument(MidiInstrumentCode instrumentId)
    {
      if (!_isActive) return;
      toneSynth.SetInstrument(instrumentId);
    }

    void HandleOnKeyTrigger(int keyCode)
    {
      if (!_isActive) return;
      var note = new ToneNote(keyCode);

      note.AddOctaves(octaveSelector.Octave);

      toneSynth.TriggerAttack(note);
    }

    void HandleOnKeyRelease(int keyCode)
    {
      if (!_isActive) return;

      var note = new ToneNote(keyCode);

      note.AddOctaves(octaveSelector.Octave);

      toneSynth.TriggerRelease(note);
    }
  }
}