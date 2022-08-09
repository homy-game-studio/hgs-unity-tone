using System.Collections;
using System.Collections.Generic;
using HGS.VirtualInstrument.Classes;
using HGS.VirtualInstrument.SO;
using UnityEngine;

namespace HGS.VirtualInstrument
{
  public class InstrumentPlayer : MonoBehaviour
  {
    [SerializeField] Instrument instrument;

    Queue<AudioSource> _availableSources = new Queue<AudioSource>();

    public bool HasSources => _availableSources.Count > 0;

    public void PlayNote(Note note)
    {
      StartCoroutine(PlayNoteCoroutine(note));
    }

    IEnumerator PlayNoteCoroutine(Note note)
    {
      var source = HasSources
        ? _availableSources.Dequeue()
        : CreateSource();

      source.pitch = note.Pitch;
      source.Play();

      yield return new WaitForSeconds(source.clip.length * source.pitch);

      _availableSources.Enqueue(source);
    }

    private AudioSource CreateSource()
    {
      var go = new GameObject("NotePlayer");
      go.transform.SetParent(transform);
      var source = go.AddComponent<AudioSource>();
      source.clip = instrument.C3;
      return source;
    }
  }
}