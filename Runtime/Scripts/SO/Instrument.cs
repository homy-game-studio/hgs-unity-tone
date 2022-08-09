using UnityEngine;

namespace HGS.VirtualInstrument.SO
{
  [CreateAssetMenu(fileName = "Instrument", menuName = "HGS/VirtualInstrument/Instrument")]
  public class Instrument : ScriptableObject
  {
    [SerializeField] AudioClip c3;

    public AudioClip C3 => c3;
  }
}