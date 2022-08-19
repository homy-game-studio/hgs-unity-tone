[![semantic-release](https://img.shields.io/badge/%20%20%F0%9F%93%A6%F0%9F%9A%80-semantic--release-e10079.svg)](https://github.com/semantic-release/semantic-release)
[![openupm](https://img.shields.io/npm/v/com.hgs.tone?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.hgs.tone/)

# Introduction

**HGS Tone** is a Synthsizer and Midi Player wrapper of [MeltySinth](https://github.com/sinshu/meltysynth) for Unity. This package turns possible play musical notes from all part of your UnityProject. Click in this image above to see youtube vídeo.

Requires Unity 2021 or bigger.

[![Open Source Midi Player - Unity HGS ToneERE](https://img.youtube.com/vi/aB1sLm0zri8/0.jpg)](https://www.youtube.com/watch?v=aB1sLm0zri8)

## Playing Musical Notes

Play note and release after default time

```cs
using HGS.Tone

public class Player: MonoBehaviour
{
  [SerializeField] ToneSynth synth;

  void Start()
  {
   synth.TriggerAttackAndRelease(ToneNote.Parse("C3"));
  }
}
```

Play note and release after 3 seconds

```cs
using HGS.Tone

public class Player: MonoBehaviour
{
  [SerializeField] ToneSynth synth;

  void Start()
  {
   synth.TriggerAttackAndRelease(ToneNote.Parse("C3"), duration:3);
  }
}
```

Play note with custom release

```cs
using HGS.Tone

public class Player: MonoBehaviour
{
  [SerializeField] ToneSynth synth;

  void Update()
  {
    if(Input.GetKeyDown(KeyCode.C)) synth.TriggerAttack(ToneNote.Parse("C3"));
    if(Input.GetKeyUp(KeyCode.C)) synth.TriggerRelease(ToneNote.Parse("C3"));
  }
}
```

## Changing instrument

Use `MidiInstrumentCode` to access Midi instrument list available.

```cs
using HGS.Tone

public class Player: MonoBehaviour
{
  [SerializeField] ToneSynth synth;

  void Start()
  {
    synth.SetInstrument(MidiInstrumentCode.Organ_Accordion);
  }
}
```

## Playing Midi files

From `Resources` folder
| Attention: for read midi files from resources, you need change file extension from `.midi` to `.bytes`.

```cs
using HGS.Tone

public class Player: MonoBehaviour
{
  [SerializeField] ToneSequencer sequencer;

  void Start()
  {
    var path = "you/path/to/midifile";
    sequencer.Play(path);
  }
}
```

From others sources

```cs
using HGS.Tone

public class Player: MonoBehaviour
{
  [SerializeField] ToneSequencer sequencer;

  void Start()
  {
    var bytes = new byte[]{}; // you file bytes
    var stream = new MemoryStream(bytes);
    sequencer.Play(stream);
  }
}
```

## Installation

OpenUPM:

`openupm add com.hgs.tone`

Package Manager:

`https://github.com/homy-game-studio/hgs-unity-tone.git#upm`

Or specify version:

`https://github.com/homy-game-studio/hgs-unity-tone.git#1.0.0`

# Samples

You can see all samples directly in **Package Manager** window.

# Contrib

If you found any bugs, have any suggestions or questions, please create an issue on github. If you want to contribute code, fork the project and follow the best practices below, and make a pull request.

## Namespace Convention

To avoid script collisions, all scripts of this package is covered by `HGS.Tone` namespace.

## Branchs

- `master` -> Keeps the unity project to development purposes.
- `upm` -> Copy of folder content `Assets/Package` to release after pull request in `master`.

Whenever a change is detected on the `master` branch, CI gets the contents of `Assets/Package`, and pushes in `upm` branch.

## Commit Convention

This package uses [semantic-release](https://github.com/semantic-release/semantic-release) to facilitate the release and versioning system. Please use angular commit convention:

```
<type>(<scope>): <short summary>
  │       │             │
  │       │             └─⫸ Summary in present tense. Not capitalized. No period at the end.
  │       │
  │       └─⫸ Commit Scope: Namespace, script name, etc..
  │
  └─⫸ Commit Type: build|ci|docs|feat|fix|perf|refactor|test
```

`Type`.:

- build: Changes that affect the build system or external dependencies (example scopes: package system)
- ci: Changes to our CI configuration files and scripts (example scopes: Circle, - BrowserStack, SauceLabs)
- docs: Documentation only changes
- feat: A new feature
- fix: A bug fix
- perf: A code change that improves performance
- refactor: A code change that neither fixes a bug nor adds a feature
- test: Adding missing tests or correcting existing tests
