
using System.Collections.Generic;

namespace HGS.Tone
{
  public class ToneScale
  {
    public string Code { get; private set; }
    public List<int> Intervals { get; private set; }

    public override string ToString()
    {
      return Code;
    }

    public static readonly ToneScale MajorTriad = new ToneScale
    {
      Code = "maj",
      Intervals = new List<int> { 0, 4, 7 }
    };

    public static readonly ToneScale MinorTriad = new ToneScale
    {
      Code = "min",
      Intervals = new List<int> { 0, 3, 7 }
    };

    public static readonly ToneScale DiminishedTriad = new ToneScale
    {
      Code = "dim",
      Intervals = new List<int> { 0, 3, 6 }
    };

    public static readonly ToneScale MajorSeventh = new ToneScale
    {
      Code = "maj7",
      Intervals = new List<int> { 0, 4, 7, 11 }
    };

    public static readonly ToneScale MinorSeventh = new ToneScale
    {
      Code = "min7",
      Intervals = new List<int> { 0, 3, 7, 10 }
    };

    static readonly List<ToneScale> _scales = new List<ToneScale>
    {
      ToneScale.MajorTriad,
      ToneScale.MinorTriad,
      ToneScale.DiminishedTriad,
      ToneScale.MajorSeventh,
      ToneScale.MinorSeventh,
    };

    public static ToneScale Random()
    {
      var index = UnityEngine.Random.Range(0, _scales.Count);
      return _scales[index];
    }

    public static ToneScale Parse(string content)
    {
      return _scales.Find(scale => scale.Code == content);
    }
  }
}