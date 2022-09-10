using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HGS.Tone
{
  public class ToneProcedural : MonoBehaviour
  {
    [SerializeField] ToneSynth synth = null;
    [SerializeField] bool isLooping = true;

    ToneChordStyle _chordStyle = null;
    List<ToneChord> _chords = new List<ToneChord>();
    ToneChord _currentChord;
    List<ToneNote> _currentBassNotes;
    int _currentChordIndex = -1;

    bool _isPlaying = false;

    int _beatCount = 0;
    int _totalBeats = 0;
    float _beatTimer = 0;
    float _beatDuration = 0.15f;
    int _tempo = 8;

    public void Stop()
    {
      _currentChordIndex = -1;
      _beatCount = 0;
      _beatTimer = 0;
      _isPlaying = false;
      synth.TriggerReleaseAll(true);
    }

    public void Generate()
    {
      var baseNote = ToneNote.Random();

      var progressions = new List<ToneChordProgression>{
        ToneChordProgression.Parse("I-IV-V-IV"),
        ToneChordProgression.Parse("I-V-vi-IV"),
        ToneChordProgression.Parse("i-vi7-iv7-v7"),
        ToneChordProgression.Parse("I-IV-♭vii°-IV"),
      };

      var progression = progressions[Random.Range(0, progressions.Count)];
      var style = ToneChordStyle.Random();
      var chords = progression.Generate(baseNote);

      SetData(chords, style);
    }

    public void SetData(List<ToneChord> chords, ToneChordStyle style)
    {
      _totalBeats = chords.Count * _tempo;
      _chordStyle = style;
      _chords = chords;
    }

    public void Play()
    {
      _isPlaying = true;
      ProcessBeat();
    }

    void ProcessStyleNotation(int id, string notation, List<ToneNote> notes)
    {
      if (id >= notes.Count) return;

      var note = notes[id];

      switch (notation)
      {
        case "_": synth.TriggerAttack(note); break;
        case "x": synth.TriggerRelease(note); break;
        case ".": synth.TriggerAttackAndRelease(note, duration: _beatDuration / 2f); break;
      }
    }

    void ProcessBeat()
    {
      var beat = _beatCount % _tempo;
      var canChangeNote = beat == 0;

      if (canChangeNote)
      {
        synth.TriggerReleaseAll();

        _currentChordIndex++;

        if (_currentChordIndex == _chords.Count) _currentChordIndex = 0;

        _currentChord = _chords[_currentChordIndex];
        _currentBassNotes = new List<ToneNote>{
            new ToneNote(_currentChord.BaseNote.Semitones).RemoveOctaves(2),
            new ToneNote(_currentChord.BaseNote.Semitones).RemoveOctaves(2).AddSemitones(7),
            new ToneNote(_currentChord.BaseNote.Semitones).RemoveOctaves(1),
        };
      }

      var bass = _chordStyle.GetBass(beat);
      var chord = _chordStyle.GetChord(beat);

      for (int i = 0; i < chord.Length; i++) ProcessStyleNotation(i, chord[i], _currentChord.Notes);
      for (int i = 0; i < bass.Length; i++) ProcessStyleNotation(i, bass[i], _currentBassNotes);

      _beatCount += 1;
    }

    void Update()
    {
      if (_isPlaying)
      {
        _beatTimer += Time.deltaTime;
        if (_beatTimer >= _beatDuration)
        {
          _beatTimer = 0;
          ProcessBeat();
          if (!isLooping && _beatCount > _totalBeats) Stop();
        }
      }
    }
  }
}