using UnityEngine;

namespace HGS.Tone.KeyboardSample
{
  public class ToneKeyboardOctave : MonoBehaviour
  {
    [SerializeField] int octave = 3;
    [SerializeField] ToneKeyboardButton icreaseButton = null;
    [SerializeField] ToneKeyboardButton decreaseButton = null;

    public int Octave => octave;

    void Awake()
    {
      icreaseButton.onTrigger += HandleOnButtonIncreaseClicked;
      decreaseButton.onTrigger += HandleOnButtonDecreaseClicked;
    }

    public void HandleOnButtonIncreaseClicked()
    {
      if (octave == 8) return;
      octave += 1;
    }

    public void HandleOnButtonDecreaseClicked()
    {
      if (octave == 0) return;
      octave -= 1;
    }
  }
}