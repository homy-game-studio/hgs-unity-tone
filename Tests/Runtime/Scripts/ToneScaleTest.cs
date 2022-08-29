using NUnit.Framework;
using UnityEngine;

namespace HGS.Tone.Testing
{
  public class ToneScaleTest
  {
    [Test]
    public void ScaleParse_Is_Valid()
    {
      Assert.AreEqual(ToneScale.MajorTriad.Intervals, ToneScale.Parse("maj").Intervals);
      Assert.AreEqual(ToneScale.MinorTriad.Intervals, ToneScale.Parse("min").Intervals);
      Assert.AreEqual(ToneScale.DiminishedTriad.Intervals, ToneScale.Parse("dim").Intervals);
    }
  }
}