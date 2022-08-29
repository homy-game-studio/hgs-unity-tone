using System;
using System.Collections.Generic;
using System.Linq;

namespace HGS.Tone
{
  public class ToneChord : ICloneable
  {
    List<ToneNote> _notes = new List<ToneNote>();
    ToneScale _scale = ToneScale.MajorTriad;

    public ToneNote BaseNote => _notes[0];
    public List<ToneNote> Notes => _notes;

    public ToneChord(ToneNote baseNote, ToneScale scale)
    {
      _scale = scale;
      _notes = _scale.Intervals
        .Select(interval => new ToneNote(baseNote.Semitones + interval))
        .ToList();
    }

    public override string ToString()
    {
      return BaseNote.ToString() + _scale.ToString();
    }

    public static ToneChord Parse(string content)
    {
      var noteArg = content
        .Substring(0, content.Length - 3)
        .ToUpper();

      var scaleArg = content
        .Substring(content.Length - 3)
        .ToLower();

      var note = ToneNote.Parse(noteArg);
      var scale = ToneScale.Parse(scaleArg);

      return new ToneChord(note, scale);
    }

    public ToneChord SetOctave(int octave)
    {
      _notes.ForEach(note => note.SetOctave(octave));
      return this;
    }

    public ToneChord AddSemitones(int amount)
    {
      _notes.ForEach(note => note.AddSemitones(amount));
      return this;
    }

    public ToneChord RemoveSemitones(int amount)
    {
      _notes.ForEach(note => note.RemoveSemitones(amount));
      return this;
    }

    public ToneChord AddOctaves(int amount)
    {
      AddSemitones(amount * 12);
      return this;
    }

    public ToneChord RemoveOctaves(int amount)
    {
      RemoveSemitones(amount * 12);
      return this;
    }

    public object Clone()
    {
      return new ToneChord(BaseNote, _scale);
    }
  }
}