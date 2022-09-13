using System;
using UnityEngine;
using UnityEngine.UI;

namespace HGS.Tone.ProceduralMusicSample
{
  public class ProceduralMusic : MonoBehaviour
  {
    [SerializeField] ToneProcedural toneProcedural;
    [SerializeField] Button generateButton;

    void Awake()
    {
      generateButton.onClick.AddListener(HandleOnClickGenerate);
    }

    private void HandleOnClickGenerate()
    {
      toneProcedural.Stop();
      toneProcedural.Generate();
      toneProcedural.Play();
    }
  }
}