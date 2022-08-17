using HGS.Tone;
using UnityEngine;

public class KeyboardPlayer : MonoBehaviour
{
  [SerializeField] ToneSynth tonePlayer = null;
  [SerializeField] int octave = 3;

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.A)) tonePlayer.TriggerAttack(ToneNote.Parse("C0").AddOctaves(octave));
    if (Input.GetKeyDown(KeyCode.Q)) tonePlayer.TriggerAttack(ToneNote.Parse("C#0").AddOctaves(octave));
    if (Input.GetKeyDown(KeyCode.S)) tonePlayer.TriggerAttack(ToneNote.Parse("D0").AddOctaves(octave));
    if (Input.GetKeyDown(KeyCode.W)) tonePlayer.TriggerAttack(ToneNote.Parse("D#0").AddOctaves(octave));
    if (Input.GetKeyDown(KeyCode.D)) tonePlayer.TriggerAttack(ToneNote.Parse("E0").AddOctaves(octave));
    if (Input.GetKeyDown(KeyCode.F)) tonePlayer.TriggerAttack(ToneNote.Parse("F0").AddOctaves(octave));
    if (Input.GetKeyDown(KeyCode.R)) tonePlayer.TriggerAttack(ToneNote.Parse("F#0").AddOctaves(octave));
    if (Input.GetKeyDown(KeyCode.G)) tonePlayer.TriggerAttack(ToneNote.Parse("G0").AddOctaves(octave));
    if (Input.GetKeyDown(KeyCode.T)) tonePlayer.TriggerAttack(ToneNote.Parse("G#0").AddOctaves(octave));
    if (Input.GetKeyDown(KeyCode.H)) tonePlayer.TriggerAttack(ToneNote.Parse("A0").AddOctaves(octave));
    if (Input.GetKeyDown(KeyCode.Y)) tonePlayer.TriggerAttack(ToneNote.Parse("A#0").AddOctaves(octave));
    if (Input.GetKeyDown(KeyCode.J)) tonePlayer.TriggerAttack(ToneNote.Parse("B0").AddOctaves(octave));

    if (Input.GetKeyUp(KeyCode.A)) tonePlayer.TriggerRelease(ToneNote.Parse("C0").AddOctaves(octave));
    if (Input.GetKeyUp(KeyCode.Q)) tonePlayer.TriggerRelease(ToneNote.Parse("C#0").AddOctaves(octave));
    if (Input.GetKeyUp(KeyCode.S)) tonePlayer.TriggerRelease(ToneNote.Parse("D0").AddOctaves(octave));
    if (Input.GetKeyUp(KeyCode.W)) tonePlayer.TriggerRelease(ToneNote.Parse("D#0").AddOctaves(octave));
    if (Input.GetKeyUp(KeyCode.D)) tonePlayer.TriggerRelease(ToneNote.Parse("E0").AddOctaves(octave));
    if (Input.GetKeyUp(KeyCode.F)) tonePlayer.TriggerRelease(ToneNote.Parse("F0").AddOctaves(octave));
    if (Input.GetKeyUp(KeyCode.R)) tonePlayer.TriggerRelease(ToneNote.Parse("F#0").AddOctaves(octave));
    if (Input.GetKeyUp(KeyCode.G)) tonePlayer.TriggerRelease(ToneNote.Parse("G0").AddOctaves(octave));
    if (Input.GetKeyUp(KeyCode.T)) tonePlayer.TriggerRelease(ToneNote.Parse("G#0").AddOctaves(octave));
    if (Input.GetKeyUp(KeyCode.H)) tonePlayer.TriggerRelease(ToneNote.Parse("A0").AddOctaves(octave));
    if (Input.GetKeyUp(KeyCode.Y)) tonePlayer.TriggerRelease(ToneNote.Parse("A#0").AddOctaves(octave));
    if (Input.GetKeyUp(KeyCode.J)) tonePlayer.TriggerRelease(ToneNote.Parse("B0").AddOctaves(octave));
  }
}
