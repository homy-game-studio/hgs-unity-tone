using System;
using TMPro;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;

namespace HGS.Tone.KeyboardSample
{
  public class ToneKeyboardInstrument : MonoBehaviour
  {
    [Header("ToneSettings")]
    [SerializeField] MidiInstrumentCode instrumentId = 0;

    [Header("Spawn")]
    [SerializeField] int numberOfInstrumentsInScreen = 0;
    [SerializeField] GameObject prefab = null;
    [SerializeField] RectTransform container = null;

    [Header("Option")]
    [SerializeField] Color selectedColor = Color.green;
    [SerializeField] Color defaultColor = Color.clear;

    [Header("Buttons")]
    [SerializeField] Button previousButton = null;
    [SerializeField] Button nextButton = null;

    public Action<MidiInstrumentCode> onChange = null;

    Queue<GameObject> _reusables = new Queue<GameObject>();
    List<GameObject> _activies = new List<GameObject>();
    bool CanReuse => _reusables.Count > 0;
    int InstrumentCount => (int)Enum.GetValues(typeof(MidiInstrumentCode)).Cast<MidiInstrumentCode>().Max() + 1;

    int _cursor = 0;

    void Awake()
    {
      previousButton.onClick.AddListener(HandleOnClickPrevious);
      nextButton.onClick.AddListener(HandleOnClickNext);
    }

    void OnEnable()
    {
      _cursor = (int)instrumentId;
      Show();
      ToggleButtons();
    }

    void Start()
    {
      onChange?.Invoke(instrumentId);
    }

    void ToggleButtons()
    {
      previousButton.interactable = _cursor > 0;
      nextButton.interactable = _cursor + numberOfInstrumentsInScreen < InstrumentCount;
    }

    void Next()
    {
      _cursor += numberOfInstrumentsInScreen;
      Show();
    }

    void Previous()
    {
      _cursor -= numberOfInstrumentsInScreen;
      Show();
    }

    private string ParseInstrumentName(MidiInstrumentCode id)
    {
      var name = id.ToString();
      return name.Replace("_", " ");
    }

    void Show()
    {
      // Mark to reuse
      _activies.ForEach(item =>
      {
        item.SetActive(false);
        _reusables.Enqueue(item);
      });

      _activies.Clear();

      var index = Mathf.Clamp(_cursor, 0, InstrumentCount);
      var target = Mathf.Clamp(_cursor + numberOfInstrumentsInScreen, 0, InstrumentCount);

      for (int i = index; i < target; i++)
      {
        var code = (MidiInstrumentCode)i;
        var instrument = ParseInstrumentName(code);
        SpawnInstrument(code, instrument);
      }
    }

    void SpawnInstrument(MidiInstrumentCode code, string instrumentName)
    {
      var go = CanReuse
        ? _reusables.Dequeue()
        : Instantiate(prefab, container);

      go.SetActive(true);
      var tmPro = go.GetComponentInChildren<TextMeshProUGUI>();
      var button = go.GetComponentInChildren<Button>();
      var image = go.GetComponentInChildren<Image>();

      tmPro.text = $"{(int)code} - {instrumentName}";
      image.color = instrumentId == code
        ? selectedColor
        : defaultColor;

      button.onClick.RemoveAllListeners();
      button.onClick.AddListener(() =>
      {
        instrumentId = code;
        onChange?.Invoke(code);
        Show();
      });

      _activies.Add(go);
    }

    private void HandleOnClickNext()
    {
      Next();
      ToggleButtons();
    }

    private void HandleOnClickPrevious()
    {
      Previous();
      ToggleButtons();
    }
  }
}