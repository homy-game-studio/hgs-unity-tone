using System.Collections.Generic;

namespace HGS.Tone
{
  public class ToneChordStyle
  {
    public string[][] Chord { get; private set; }
    public string[][] Bass { get; private set; }

    public string[] GetBass(int beat)
    {
      return Bass[beat];
    }

    public string[] GetChord(int beat)
    {
      return Chord[beat];
    }

    public static ToneChordStyle Once = new ToneChordStyle
    {
      Bass = new string[][]
      {
        new string[]{"_"," "," "},
        new string[]{" "," "," "},
        new string[]{" "," "," "},
        new string[]{" "," "," "},
        new string[]{" "," "," "},
        new string[]{" "," "," "},
        new string[]{" "," "," "},
        new string[]{" "," "," "}
      },
      Chord = new string[][]
      {
        new string[]{"_","_","_","_"},
        new string[]{" "," "," "," "},
        new string[]{" "," "," "," "},
        new string[]{" "," "," "," "},
        new string[]{" "," "," "," "},
        new string[]{" "," "," "," "},
        new string[]{" "," "," "," "},
        new string[]{" "," "," "," "},
      }
    };

    public static ToneChordStyle BasicOne = new ToneChordStyle
    {
      Bass = new string[][]
      {
        new string[]{"_"," "," "},
        new string[]{" "," "," "},
        new string[]{" "," "," "},
        new string[]{" "," "," "},
        new string[]{" "," "," "},
        new string[]{" "," "," "},
        new string[]{" "," "," "},
        new string[]{" "," "," "},
        new string[]{" "," "," "},
        new string[]{" "," "," "},
      },
      Chord = new string[][]
      {
        new string[]{"_"," "," "," "},
        new string[]{" "," "," "," "},
        new string[]{" ","_","_"," "},
        new string[]{" "," "," "," "},
        new string[]{"_"," "," "," "},
        new string[]{" "," "," "," "},
        new string[]{" ","_","_"," "},
        new string[]{" "," "," "," "},
      }
    };

    public static ToneChordStyle BasicTwo = new ToneChordStyle
    {
      Bass = new string[][]
      {
        new string[]{"_"," "," "},
        new string[]{" "," "," "},
        new string[]{" "," "," "},
        new string[]{" "," "," "},
        new string[]{" "," "," "},
        new string[]{" "," "," "},
        new string[]{" "," "," "},
        new string[]{" "," "," "},
      },
      Chord = new string[][]
      {
        new string[]{"_"," "," "," "},
        new string[]{" "," "," "," "},
        new string[]{" ","_"," "," "},
        new string[]{" "," "," "," "},
        new string[]{" "," ","_"," "},
        new string[]{" "," "," "," "},
        new string[]{" ","_"," "," "},
        new string[]{" "," "," "," "},
      }
    };

    public static ToneChordStyle DanceOne = new ToneChordStyle
    {
      Bass = new string[][]
      {
        new string[]{"_"," "," "},
        new string[]{" "," "," "},
        new string[]{" "," ","_"},
        new string[]{" "," "," "},
        new string[]{"_"," "," "},
        new string[]{" "," "," "},
        new string[]{" "," ","_"},
        new string[]{" "," "," "},
      },
      Chord = new string[][]
      {
        new string[]{"_","_","_","_"},
        new string[]{" "," "," "," "},
        new string[]{" "," "," "," "},
        new string[]{"_","_","_","_"},
        new string[]{" "," "," "," "},
        new string[]{" "," "," "," "},
        new string[]{"_","_","_","_"},
        new string[]{" "," "," "," "},
      }
    };

    public static ToneChordStyle Reggaeton = new ToneChordStyle
    {
      Bass = new string[][]
     {
        new string[]{"_"," "," "},
        new string[]{" "," "," "},
        new string[]{" "," "," "},
        new string[]{" "," "," "},
        new string[]{" ","_"," "},
        new string[]{" "," "," "},
        new string[]{" "," "," "},
        new string[]{" "," "," "},
     },
      Chord = new string[][]
     {
        new string[]{" "," "," "," "},
        new string[]{" "," "," "," "},
        new string[]{" "," "," "," "},
        new string[]{".",".",".","."},
        new string[]{" "," "," "," "},
        new string[]{" "," "," "," "},
        new string[]{"_","_","_","_"},
        new string[]{" "," "," "," "},
     }
    };

    private static List<ToneChordStyle> _styles = new List<ToneChordStyle>{
      Once,
      BasicOne,
      BasicTwo,
      DanceOne,
      Reggaeton
    };

    public static ToneChordStyle Random()
    {
      var index = UnityEngine.Random.Range(0, _styles.Count);
      return _styles[index];
    }
  }
}