using System;
using System.Collections.Generic;
using System.Linq;

namespace HGS.Tone
{
  public class ToneNote : ICloneable
  {
    static Dictionary<string, int> _codes = new Dictionary<string, int>
    {
      {"C",0},
      {"C#",1},
      {"D",2},
      {"D#",3},
      {"E",4},
      {"F",5},
      {"F#",6},
      {"G",7},
      {"G#",8},
      {"A",9},
      {"A#",10},
      {"B",11},
    };

    public int Semitones { get; set; }
    public int NoteNumber => Semitones % 12;
    public int Octave => (Semitones - NoteNumber) / 12;

    public ToneNote() { }
    public ToneNote(int key)
    {
      Semitones = key;
    }

    public static ToneNote Random(int octave = 4)
    {
      var code = UnityEngine.Random.Range(0, 12);
      return new ToneNote((octave * 12) + code);
    }

    public static ToneNote Parse(string content)
    {
      var noteName = content
            .Substring(0, content.Length - 1)
            .ToUpper();
      var octaveArg = content.Substring(content.Length - 1);
      var octaves = int.Parse(octaveArg);

      var note = new ToneNote
      {
        Semitones = _codes[noteName]
      };

      note.AddOctaves(octaves);

      return note;
    }

    public override string ToString()
    {
      var noteName = _codes
        .Where(tuple => tuple.Value == NoteNumber)
        .Select(tuple => tuple.Key)
        .First();

      return $"{noteName}{Octave}";
    }

    public ToneNote SetOctave(int value)
    {
      Semitones = (value * 12) + NoteNumber;
      return this;
    }

    public ToneNote AddOctaves(int amount)
    {
      AddSemitones(amount * 12);
      return this;
    }

    public ToneNote RemoveOctaves(int amount)
    {
      RemoveSemitones(amount * 12);
      return this;
    }

    public ToneNote RemoveSemitones(int amount)
    {
      Semitones -= amount;
      return this;
    }

    public ToneNote AddSemitones(int amount)
    {
      Semitones += amount;
      return this;
    }

    public object Clone()
    {
      return this.MemberwiseClone();
    }
  }
}