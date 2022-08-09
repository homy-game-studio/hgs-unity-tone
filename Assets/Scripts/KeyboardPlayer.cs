using HGS.VirtualInstrument;
using HGS.VirtualInstrument.Classes;
using UnityEngine;

public class KeyboardPlayer : MonoBehaviour
{
  [SerializeField] InstrumentPlayer instrumentPlayer = null;

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.A)) instrumentPlayer.PlayNote(Note.C);
    if (Input.GetKeyDown(KeyCode.Q)) instrumentPlayer.PlayNote(Note.CSus);
    else if (Input.GetKeyDown(KeyCode.S)) instrumentPlayer.PlayNote(Note.D);
    else if (Input.GetKeyDown(KeyCode.W)) instrumentPlayer.PlayNote(Note.DSus);
    else if (Input.GetKeyDown(KeyCode.D)) instrumentPlayer.PlayNote(Note.E);
    else if (Input.GetKeyDown(KeyCode.F)) instrumentPlayer.PlayNote(Note.F);
    else if (Input.GetKeyDown(KeyCode.R)) instrumentPlayer.PlayNote(Note.FSus);
    else if (Input.GetKeyDown(KeyCode.G)) instrumentPlayer.PlayNote(Note.G);
    else if (Input.GetKeyDown(KeyCode.T)) instrumentPlayer.PlayNote(Note.GSus);
    else if (Input.GetKeyDown(KeyCode.H)) instrumentPlayer.PlayNote(Note.A);
    else if (Input.GetKeyDown(KeyCode.Y)) instrumentPlayer.PlayNote(Note.ASus);
    else if (Input.GetKeyDown(KeyCode.J)) instrumentPlayer.PlayNote(Note.B);
  }
}
