using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HGS.Tone.KeyboardSample
{
  public class ToneKeyboardDisplayPanelBtn : MonoBehaviour
  {
    [SerializeField] Button button = null;
    [SerializeField] List<ToneKeyboardDisplayPanel> panelsToShow = null;
    [SerializeField] List<ToneKeyboardDisplayPanel> panelsToHide = null;

    void Awake()
    {
      button.onClick.AddListener(HandleOnClickMenuButton);
    }

    private void HandleOnClickMenuButton()
    {
      panelsToShow.ForEach(panel => panel.Show());
      panelsToHide.ForEach(panel => panel.Hide());
    }
  }
}