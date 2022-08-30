using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HGS.Tone.Testing
{
  public class ToneChordTest
  {
    [Test]
    public void ChordParse_Is_Valid()
    {
      var baseNote = ToneNote.Parse("C4");

      var currentMaj = new ToneChord(baseNote, ToneScale.MajorTriad);
      var currentDim = new ToneChord(baseNote, ToneScale.DiminishedTriad);

      var currentMajNoteNames = currentMaj.Notes.Select(note => note.ToString());
      var currentDimNoteNames = currentDim.Notes.Select(note => note.ToString());

      var expectedMaj = new List<string> { "C4", "E4", "G4" };
      var expectedDim = new List<string> { "C4", "D#4", "F#4" };

      Assert.AreEqual(string.Join(",", expectedMaj), string.Join(",", currentMajNoteNames));
      Assert.AreEqual(string.Join(",", expectedDim), string.Join(",", currentDimNoteNames));
    }
  }
}