using UnityEngine;

namespace HGS.Tone.MidiCallback
{
  public class MidiCallbackSample : MonoBehaviour
  {
    [SerializeField] string midiName = "";
    [SerializeField] ToneSequencer sequencer;

    void Awake()
    {
      sequencer.onMidiMessage += HandleOnMidiMessage;
    }

    void Start()
    {
      sequencer.Play(midiName);
    }

    private void HandleOnMidiMessage(int channel, int command, int data1, int data2)
    {
      Debug.Log($"MidiMessageCallback: {channel}, {command}, {data1}, {data2}");
    }
  }
}