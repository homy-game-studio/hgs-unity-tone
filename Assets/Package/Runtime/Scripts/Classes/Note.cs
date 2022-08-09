using UnityEngine;

namespace HGS.VirtualInstrument.Classes
{
  public class Note
  {
    public static Note C = new Note { step = 0 };
    public static Note CSus = new Note { step = 1 };
    public static Note D = new Note { step = 2 };
    public static Note DSus = new Note { step = 3 };
    public static Note E = new Note { step = 4 };
    public static Note F = new Note { step = 5 };
    public static Note FSus = new Note { step = 6 };
    public static Note G = new Note { step = 7 };
    public static Note GSus = new Note { step = 8 };
    public static Note A = new Note { step = 9 };
    public static Note ASus = new Note { step = 10 };
    public static Note B = new Note { step = 11 };

    public int step { get; private set; }
    public float Pitch => Mathf.Pow(2f, step / 12f);
  }
}