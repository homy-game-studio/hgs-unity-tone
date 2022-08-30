using UnityEngine;

namespace HGS.Tone.KeyboardSample
{
  public class ToneKeyboardDisplayPanel : MonoBehaviour
  {
    [SerializeField] GameObject content = null;

    public void Hide()
    {
      content.SetActive(false);
    }

    public void Show()
    {
      content.SetActive(true);
    }
  }
}