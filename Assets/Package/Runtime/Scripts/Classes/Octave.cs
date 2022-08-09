using UnityEngine;

namespace HGS.VirtualInstrument.Classes
{
  public static class Octave
  {
    public static float NoteToPitch(Note note, int octave)
    {
      var step = (int)note + (octave * 12);
      return Mathf.Pow(2f, (float)step / 12f);
    }
  }
}