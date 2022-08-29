using NUnit.Framework;

namespace HGS.Tone.Testing
{
  public class ToneChordTest
  {
    [Test]
    public void ChordParse_Is_Valid()
    {
      var baseNote = ToneNote.Parse("C4");

      var expected = new ToneChord(baseNote, ToneScale.MajorTriad);
      var current = ToneChord.Parse("C4maj");

      Assert.AreEqual(string.Join(",", expected.Notes), string.Join(",", current.Notes));
    }
  }
}