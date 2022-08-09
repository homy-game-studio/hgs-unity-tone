using UnityEngine;

namespace HGS.VirtualInstrument.SO
{
  [CreateAssetMenu(fileName = "Instrument", menuName = "HGS/VirtualInstrument/Instrument")]
  public class Instrument : ScriptableObject
  {
    [SerializeField] AudioClip c;
    [SerializeField] int octave = 3;

    public AudioClip C => c;
    public int Octave => octave;
  }
}