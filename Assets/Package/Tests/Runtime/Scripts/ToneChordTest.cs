using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HGS.Tone.Testing
{
    public class ToneChordTest
    {
        private static readonly object[] ChordTestCases =
        {
            new object[] { "C", ToneNote.Parse("C4"), ToneScale.MajorTriad, new[] { "C4", "E4", "G4" } },
            new object[] { "Cm", ToneNote.Parse("C4"), ToneScale.MinorTriad, new[] { "C4", "D#4", "G4" } },
            new object[] { "C#m", ToneNote.Parse("C#4"), ToneScale.MinorTriad, new[] { "C#4", "E4", "G#4" } },
            new object[] { "Em", ToneNote.Parse("E4"), ToneScale.MinorTriad, new[] { "E4", "G4", "B4" } },
            new object[] { "Em7", ToneNote.Parse("E4"), ToneScale.MinorSeventh, new[] { "E4", "G4", "B4", "D5" } },
            new object[] { "Cdim", ToneNote.Parse("C4"), ToneScale.DiminishedTriad, new[] { "C4", "D#4", "F#4" } },
            new object[] { "C7", ToneNote.Parse("C4"), ToneScale.MajorSeventh, new[] { "C4", "E4", "G4", "A#4" } },
            new object[] { "Cm7", ToneNote.Parse("C4"), ToneScale.MinorSeventh, new[] { "C4", "D#4", "G4", "A#4" } },
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