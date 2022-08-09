using HGS.VirtualInstrument;
using HGS.VirtualInstrument.Classes;
using UnityEngine;

public class KeyboardPlayer : MonoBehaviour
{
  [SerializeField] InstrumentPlayer instrumentPlayer = null;
  [SerializeField] int octave = 3;

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.A)) instrumentPlayer.PlayNote(Note.C, octave);
    if (Input.GetKeyDown(KeyCode.Q)) instrumentPlayer.PlayNote(Note.CSus, octave);
    else if (Input.GetKeyDown(KeyCode.S)) instrumentPlayer.PlayNote(Note.D, octave);
    else if (Input.GetKeyDown(KeyCode.W)) instrumentPlayer.PlayNote(Note.DSus, octave);
    else if (Input.GetKeyDown(KeyCode.D)) instrumentPlayer.PlayNote(Note.E, octave);
    else if (Input.GetKeyDown(KeyCode.F)) instrumentPlayer.PlayNote(Note.F, octave);
    else if (Input.GetKeyDown(KeyCode.R)) instrumentPlayer.PlayNote(Note.FSus, octave);
    else if (Input.GetKeyDown(KeyCode.G)) instrumentPlayer.PlayNote(Note.G, octave);
    else if (Input.GetKeyDown(KeyCode.T)) instrumentPlayer.PlayNote(Note.GSus, octave);
    else if (Input.GetKeyDown(KeyCode.H)) instrumentPlayer.PlayNote(Note.A, octave);
    else if (Input.GetKeyDown(KeyCode.Y)) instrumentPlayer.PlayNote(Note.ASus, octave);
    else if (Input.GetKeyDown(KeyCode.J)) instrumentPlayer.PlayNote(Note.B, octave);
  }
}
