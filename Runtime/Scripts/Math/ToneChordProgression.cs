using System.Collections.Generic;
using System.Linq;

namespace HGS.Tone
{
  public class ToneChordProgression
  {
    private static readonly Dictionary<string, int> _romanDict = new Dictionary<string, int>{
        {"I", 0},
        {"II", 2},
        {"III", 4},
        {"IV", 5},
        {"V", 7},
        {"VI", 9},
        {"VII", 11},
    };

    public List<string> RomanNotation { get; private set; }

    private ToneScale GetRomanScale(string roman)
    {
      if (roman.EndsWith("°")) return ToneScale.DiminishedTriad;

      if (roman.EndsWith("7"))
      {
        return roman.Any(c => char.IsLower(c))
          ? ToneScale.MinorSeventh
          : ToneScale.MajorSeventh;
      }

      return roman.Any(c => char.IsLower(c))
        ? ToneScale.MinorTriad
        : ToneScale.MajorTriad;
    }

    private ToneNote GetRomanNote(string roman)
    {
      var isBemol = roman.StartsWith("♭");

      var normalized = roman
        .Replace("°", "")
        .Replace("7", "")
        .Replace("♭", "");

      var note = new ToneNote(_romanDict[normalized.ToUpper()]);

      if (isBemol) note.RemoveSemitones(1);

      return note;
    }

    private ToneChord RomanToChord(ToneNote baseNote, string roman)
    {
      var note = GetRomanNote(roman)
        .AddSemitones(baseNote.Semitones);
      var scale = GetRomanScale(roman);

      return new ToneChord(note, scale);
    }

    public static ToneChordProgression Parse(string content)
    {
      // sample: I-IV-V
      var romanNotation = content
        .Split("-")
        .ToList();

      return new ToneChordProgression
      {
        RomanNotation = romanNotation
      };
    }

    public List<ToneChord> Generate(ToneNote baseNote)
    {
      return RomanNotation
          // Converts from roman notation to chord
          .Select(notation => RomanToChord(baseNote, notation))
          // Fix note octaves
          .Select(chord => chord.SetOctave(baseNote.Octave))
          .ToList();
    }
  }
}