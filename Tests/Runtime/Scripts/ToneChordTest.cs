using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HGS.Tone.Testing
{
    public class ToneChordTest
    {
        private static readonly object[] ChordTestCases =
        {
            new object[] { "Major Triad", ToneNote.Parse("C4"), ToneScale.MajorTriad, new[] { "C4", "E4", "G4" } },
            new object[] { "Minor Triad", ToneNote.Parse("C4"), ToneScale.MinorTriad, new[] { "C4", "D#4", "G4" } },
            new object[] { "Minor Triad E", ToneNote.Parse("E4"), ToneScale.MinorTriad, new[] { "E4", "G4", "B4" } },
            new object[] { "Minor Seventh E", ToneNote.Parse("E4"), ToneScale.MinorSeventh, new[] { "E4", "G4", "B4", "D5" } },
            new object[] { "Diminished Triad", ToneNote.Parse("C4"), ToneScale.DiminishedTriad, new[] { "C4", "D#4", "F#4" } },
            new object[] { "Major Seventh", ToneNote.Parse("C4"), ToneScale.MajorSeventh, new[] { "C4", "E4", "G4", "B4" } },
            new object[] { "Minor Seventh", ToneNote.Parse("C4"), ToneScale.MinorSeventh, new[] { "C4", "D#4", "G4", "A#4" } },
        };

        [Test, TestCaseSource(nameof(ChordTestCases))]
        public void ChordParse_ShouldReturnExpectedNotes(string name, ToneNote baseNote, ToneScale scale, string[] expectedNotes)
        {
            var chord = new ToneChord(baseNote, scale);
            var actualNoteNames = chord.Notes.Select(n => n.ToString()).ToArray();

            Assert.AreEqual(expectedNotes, actualNoteNames, $"Failed for {name}");
        }
    }
}