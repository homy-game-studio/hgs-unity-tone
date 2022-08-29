using System.Collections.Generic;
using System.Linq;

namespace HGS.Tone
{
  public class ToneChordProgression
  {
    private static readonly Dictionary<string, int> _romanDict = new Dictionary<string, int>{
        {"I", 0},
        {"II", 1},
        {"III", 2},
        {"IV", 3},
        {"V", 4},
        {"VI", 5},
        {"VII", 6},
        {"VIII", 7},
        {"IX", 8},
        {"X", 9},
        {"XI", 10},
        {"XII", 11},
    };

    public List<string> RomanNotation { get; private set; }

    public static readonly ToneChordProgression CircleProgression = new ToneChordProgression
    {
      RomanNotation = new List<string> { "x", "iii", "VIII", "I" }
    };

    public static readonly ToneChordProgression EightBarBlues = new ToneChordProgression
    {
      RomanNotation = new List<string> { "I", "VIII", "VI", "VI", "I", "VIII", "I", "VIII" }
    };

    private static readonly List<ToneChordProgression> _progressions = new List<ToneChordProgression>{
      CircleProgression,
      EightBarBlues
    };

    public static ToneChordProgression Random()
    {
      var index = UnityEngine.Random.Range(0, _progressions.Count);
      return _progressions[index];
    }

    private ToneScale GetRomanScale(string roman)
    {
      return roman.Any(c => char.IsLower(c))
        ? ToneScale.MinorTriad
        : ToneScale.MajorTriad;
    }

    private ToneNote GetRomanNote(string roman)
    {
      return new ToneNote(_romanDict[roman.ToUpper()]);
    }

    private ToneChord RomanToChord(ToneNote baseNote, string roman)
    {
      var note = GetRomanNote(roman)
        .AddSemitones(baseNote.Semitones);
      var scale = GetRomanScale(roman);

      return new ToneChord(note, scale);
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