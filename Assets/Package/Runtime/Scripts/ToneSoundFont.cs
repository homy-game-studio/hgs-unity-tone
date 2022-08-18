using System.IO;
using MeltySynth;
using UnityEngine;

namespace HGS.Tone
{
  [CreateAssetMenu(fileName = "ToneSoundFont", menuName = "HGS/Tone/ToneSoundFont")]
  public class ToneSoundFont : ScriptableObject
  {
    [SerializeField] string soundFontFile = "GeneralUserGS";

    SoundFont _soundFont = null;

    public bool IsLoaded => _soundFont != null;

    public SoundFont SoundFont
    {
      get
      {
        if (!IsLoaded) throw new System.Exception("SoundFont is null! Use Load() to load SoundFont file into ToneSoundFont");
        return _soundFont;
      }
    }

    void OnEnable()
    {
      Load();
    }

    public void Load()
    {
      Load(soundFontFile);
    }

    public void Load(string resourceName)
    {
      var asset = Resources.Load<TextAsset>(resourceName);
      var stream = new MemoryStream(asset.bytes);
      Load(stream);
    }

    public void Load(Stream stream)
    {
      _soundFont = new SoundFont(stream);
    }
  }
}