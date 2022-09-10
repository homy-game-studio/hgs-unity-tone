using NUnit.Framework;

namespace HGS.Tone.Testing
{
  public class ToneChordProgressionTest
  {
    [Test]
    public void Generate_Is_Valid()
    {
      var progression = ToneChordProgression.Parse("I-IV-V");

      var circleProgressionC = progression.Generate(ToneNote.Parse("C4"));
      var circleProgressionD = progression.Generate(ToneNote.Parse("D2"));

      var expectedC = "A4min,D4min,G4maj,C4maj";
      var expectedD = "B2min,E2min,A2maj,D2maj";

      var currentC = string.Join(",", circleProgressionC);
      var currentD = string.Join(",", circleProgressionD);

      Assert.AreEqual(expectedC, currentC);
      Assert.AreEqual(expectedD, currentD);
    }
  }
}