using NUnit.Framework;

namespace HGS.Tone.Testing
{
  public class ToneNoteTest
  {
    [Test]
    public void NoteParse_Is_Valid()
    {
      var noteC = ToneNote.Parse("C3");
      var noteD = ToneNote.Parse("D3");
      var noteE = ToneNote.Parse("E3");
      var noteF = ToneNote.Parse("F3");
      var noteG = ToneNote.Parse("G3");
      var noteA = ToneNote.Parse("A3");
      var noteB = ToneNote.Parse("B3");

      // Octaves
      Assert.AreEqual(3, noteC.Octave);
      Assert.AreEqual(3, noteD.Octave);
      Assert.AreEqual(3, noteE.Octave);
      Assert.AreEqual(3, noteF.Octave);
      Assert.AreEqual(3, noteG.Octave);
      Assert.AreEqual(3, noteA.Octave);
      Assert.AreEqual(3, noteB.Octave);

      // Code
      Assert.AreEqual(36, noteC.Semitones); // 36 = 3 * 12 + 0
      Assert.AreEqual(38, noteD.Semitones); // 38 = 3 * 12 + 2
      Assert.AreEqual(40, noteE.Semitones); // 40 = 3 * 12 + 4
      Assert.AreEqual(41, noteF.Semitones); // 41 = 3 * 12 + 5
      Assert.AreEqual(43, noteG.Semitones); // 43 = 3 * 12 + 7
      Assert.AreEqual(45, noteA.Semitones); // 45 = 3 * 12 + 9
      Assert.AreEqual(47, noteB.Semitones); // 47 = 3 * 12 + 11
    }

    [Test]
    public void ToString_Returns_valid()
    {
      var noteA = new ToneNote(0);  //  C0
      var noteB = new ToneNote(1);  //  C#0
      var noteC = new ToneNote(12);  //  C1

      Assert.AreEqual("C0", noteA.ToString());
      Assert.AreEqual("C#0", noteB.ToString());
      Assert.AreEqual("C1", noteC.ToString());
    }

    [Test]
    public void AddSemitones_adds_correctly()
    {
      var note = ToneNote
        .Parse("C3")
        .AddSemitones(1);

      Assert.AreEqual("C#3", note.ToString());
    }

    [Test]
    public void RemoveSemitones_removes_correctly()
    {
      var note = ToneNote
        .Parse("D#3")
        .RemoveSemitones(1);

      Assert.AreEqual("D3", note.ToString());
    }

    [Test]
    public void RemoveOctaves_removes_correctly()
    {
      var note = ToneNote
        .Parse("C#3")
        .RemoveOctaves(2);
      Assert.AreEqual("C#1", note.ToString());
    }

    [Test]
    public void AddOctaves_adds_correctly()
    {
      var note = ToneNote
        .Parse("F#1")
        .AddOctaves(3);

      Assert.AreEqual("F#4", note.ToString());
    }
  }
}