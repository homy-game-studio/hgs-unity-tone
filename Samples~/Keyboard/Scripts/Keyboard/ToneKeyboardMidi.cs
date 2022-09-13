using System;
using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace HGS.Tone.KeyboardSample
{
  public class ToneKeyboardMidi : MonoBehaviour
  {
    [Header("Midi")]
    [SerializeField] List<TextAsset> midiFiles = new List<TextAsset>();

    [Header("Spawn")]
    [SerializeField] int numberOfElementsInScreen = 0;
    [SerializeField] GameObject prefab = null;
    [SerializeField] RectTransform container = null;

    [Header("Option")]
    [SerializeField] Color selectedColor = Color.green;
    [SerializeField] Color defaultColor = Color.clear;

    [Header("Buttons")]
    [SerializeField] Button previousButton = null;
    [SerializeField] Button nextButton = null;

    public Action<TextAsset> onTrigger = null;

    Queue<GameObject> _reusables = new Queue<GameObject>();
    List<GameObject> _activies = new List<GameObject>();
    bool CanReuse => _reusables.Count > 0;
    int FileCount => midiFiles.Count;

    int _cursor = 0;
    TextAsset _current = null;

    void Awake()
    {
      previousButton.onClick.AddListener(HandleOnClickPrevious);
      nextButton.onClick.AddListener(HandleOnClickNext);
    }

    void OnEnable()
    {
      Show();
      ToggleButtons();
    }

    void ToggleButtons()
    {
      previousButton.interactable = _cursor > 0;
      nextButton.interactable = _cursor + numberOfElementsInScreen < FileCount;
    }

    void Next()
    {
      _cursor += numberOfElementsInScreen;
      Show();
    }

    void Previous()
    {
      _cursor -= numberOfElementsInScreen;
      Show();
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

      var index = Mathf.Clamp(_cursor, 0, FileCount);
      var target = Mathf.Clamp(_cursor + numberOfElementsInScreen, 0, FileCount);

      for (int i = index; i < target; i++)
      {
        var file = midiFiles[i];
        SpawnInstrument(i, file);
      }
    }

    void SpawnInstrument(int index, TextAsset file)
    {
      var go = CanReuse
        ? _reusables.Dequeue()
        : Instantiate(prefab, container);

      go.SetActive(true);
      var tmPro = go.GetComponentInChildren<TextMeshProUGUI>();
      var button = go.GetComponentInChildren<Button>();
      var image = go.GetComponentInChildren<Image>();

      tmPro.text = $"{index} - {file.name}";
      image.color = _current == file
        ? selectedColor
        : defaultColor;

      button.onClick.RemoveAllListeners();
      button.onClick.AddListener(() =>
      {
        _current = _current == file
          ? null
          : file;

        onTrigger?.Invoke(_current);

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