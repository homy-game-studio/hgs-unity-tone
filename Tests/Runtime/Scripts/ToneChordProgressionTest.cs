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

            var expectedC = "C4maj,F4maj,G4maj";
            var expectedD = "D2maj,G2maj,A2maj";

            var currentC = string.Join(",", circleProgressionC);
            var currentD = string.Join(",", circleProgressionD);

            Assert.AreEqual(expectedC, currentC);
            Assert.AreEqual(expectedD, currentD);
        }
    }
}