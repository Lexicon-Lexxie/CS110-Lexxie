# 12B · StimuLye (Unity vertical slice) — Lexxie

Personal work for **CS110 Development Road, Week 12B (Execute + return)**.
Solo project. Goal: *a beautiful playable scene in Unity with a 3D player viewed in third person*, built as the first vertical slice of **StimuLye** (dark opening → one looping ward corridor → one interactive "Stimuli" memory room).

- **GitHub repo:** https://github.com/Lexicon-Lexxie/CS110-Lexxie (this folder lives at `Week12/12B/`, next to `Week12/12A/`)
- **Public verification code:** `VIEW-9265F91D9B43EF8355AB19A9` (also in [`PERSONAL-SUBMISSION-CODE.txt`](PERSONAL-SUBMISSION-CODE.txt))
- **Contact:** Discord `Samdan9` · availability in [`Context/availability.ics`](Context/availability.ics)

---

## 1. Quick start

| I want to… | Do this |
|---|---|
| **Read the report** (notes, tables, boards, links) | Double-click [`index.html`](index.html). It works offline; images and styling are embedded. |
| **Open the game project** | Unity Hub → *Add project from disk* → select `project-source/UnityProject/`. Use **Unity 6000.6.7f1 (Unity 6.6)**. |
| **Play the scene** | Open `Assets/Scenes/SampleScene.unity`, press **Play**. Move with **WASD**, sprint with **Shift**, jump with **Space**, look with the mouse. |
| **See the test evidence** | [`Evidence/testfixconsole.png`](Evidence/testfixconsole.png) |
| **Find issued course PDFs** | [`Requirements/issued-pdfs/`](Requirements/issued-pdfs/) |
| **Submit on Canvas** | Repo URL **and** the `VIEW-…` code above (see §8). |

First open of the Unity project is slow: Unity regenerates the `Library/` folder (not committed) and compiles HDRP shaders.

---

## 2. Folder map

```
12B/
├── README.md                     ← you are here
├── index.html                    ← styled offline report (start here for the written work)
├── PERSONAL-SUBMISSION-CODE.txt  ← named public VIEW code (must travel with the work)
├── .gitignore                    ← Unity + private-key ignores
│
├── Context/                      ← WHAT the project is and why
│   ├── notes.md                  ← all written answers: prep, pitch, AI plan, huddle, tech, tables
│   ├── Terms.md                  ← course glossary (huddle, pipeline, handoff, …)
│   ├── availability.ics          ← calendar slots (Nov 10 + Nov 12, 16:00–17:00 Pacific)
│   └── Course-README.txt         ← original README supplied by the course export
│
├── Requirements/                 ← official records, drafts, submission paperwork
│   ├── issued-pdfs/              ← numbered issued records (PREP + FORM PDFs)
│   ├── Working-Draft.pdf         ← NOT an issued record, just a draft printout
│   ├── work.json                 ← restores the editable draft via "My work" on the course site
│   └── prefs.json                ← course site preferences (timer, last page)
│
├── Resources/                    ← visuals used by the report
│   └── boards/                   ← whiteboard exports (prep, pipeline, huddle, report A)
│
├── Evidence/                     ← proof of tested work
│   └── testfixconsole.png        ← Unity Play-mode screenshot with Console (2026-11-12)
│
└── project-source/               ← the engine project
    ├── ADD-YOUR-ENGINE-FILES-HERE.txt   ← course placeholder (now fulfilled by UnityProject/)
    └── UnityProject/             ← Unity 6.6 HDRP project (open THIS folder in Unity Hub)
        ├── Assets/
        │   ├── StimuLye/         ← ★ ALL MY OWN WORK GOES HERE (see §4)
        │   ├── Scenes/           ← SampleScene (template) + baked lighting
        │   ├── SampleSceneAssets/← template content: controllers, meshes, materials, textures
        │   ├── HDRPDefaultResources/ ← HDRP defaults (do not edit)
        │   └── InputSystem_Actions.inputactions
        ├── Packages/             ← manifest.json + packages-lock.json
        └── ProjectSettings/      ← Unity project settings (committed on purpose)
```

---

## 3. Unity project facts

| Item | Value |
|---|---|
| Editor version | `6000.6.7f1` (Unity 6.6) |
| Template | **High Definition 3D (HDRP)** sample scene |
| Render pipeline | HDRP `com.unity.render-pipelines.high-definition 17.6.0` |
| Camera | Cinemachine `6.6.0` |
| Input | Input System `1.20.1` (`Assets/InputSystem_Actions.inputactions`) |
| Build scene list | `Assets/Scenes/SampleScene.unity` |
| Project / product name | `DangerousGame` (template default, set in Project Settings) |
| IDE packages | Visual Studio `2.0.28`, Rider `3.1.0` |

**Where the important template code lives** (all inside `project-source/UnityProject/Assets/SampleSceneAssets/`):

| Purpose | Path |
|---|---|
| Third-person player movement | `Controllers/ThirdPersonController/Scripts/ThirdPersonController.cs` |
| Input bridge (WASD, mouse, Space, Shift) | `Controllers/Common/InputSystem/StarterAssetsInputs.cs` |
| Pushing rigid bodies | `Controllers/Common/BasicRigidBodyPush.cs` |
| First-person alternative (unused) | `Controllers/FirstPersonController/FirstPersonController.cs` |
| Scene-view camera sync (editor helper) | `Scripts/SyncSceneViewCamera.cs` |
| Meshes / materials / textures / VFX | `Meshes/`, `Materials/`, `Textures/`, `Particles/` |
| Volume + lighting profiles | `Settings/Volumes/`, `Settings/LightingSettings/` |

---

## 4. Where new work goes (naming rules)

Keep paths **short** (Windows 256-character limit) and keep my files separate from template files so the template can be updated or deleted without touching mine.

```
Assets/StimuLye/
├── Scripts/      C#: StimulusItem, RoomStabilizer, StaticController, PauseMenuController
├── Prefabs/      modular ward pieces (wall, floor, door), Stimulus_MemoryObject
├── Materials/    shared dark-void + lit-hospital materials (swapped by RoomStabilizer)
├── Models/       imported FBX files (e.g. NaN from Mixamo)
├── Animations/   avatars, animator controllers
├── Audio/        Static cues, stimulus sounds
└── Scenes/       StimuLye scenes (keep SampleScene untouched as the reference)
```

- Folder names: `PascalCase`. Scripts: class name = file name. Prefabs: `Noun_Variant` (e.g. `Stimulus_MemoryObject`).
- One Git commit per finished stage, message like `Stage 2: import NaN, humanoid rig, 0 console errors`.
- Every third-party asset must be credited in a `Requirements/Credits.txt` (create it when the first outside asset is added).
- Empty folders contain a `.gitkeep` so Git keeps them; Unity ignores those files.

---

## 5. Planned architecture (from the Huddle code tables)

| Class | Responsibility | GameObject |
|---|---|---|
| `ThirdPersonController` | Movement, sprint, jump, gravity, animator parameters | `PlayerArmature` |
| `StarterAssetsInputs` | Reads WASD / mouse / Space / Shift from the Input System | `PlayerArmature` |
| `CharacterController` | Unity capsule collision component | `PlayerArmature` |
| `StimulusItem` | Detects proximity, fires interaction events on pickup | `Stimulus_MemoryObject` |
| `RoomStabilizer` | Swaps room materials from dark void to hospital when a Stimulus is collected | `Environment_Manager` |
| `StaticController` | Raises audio distortion as the Static entity nears | `Static_Antagonist` |
| `PauseMenuController` | Esc → pause time, show the CRT pause menu | `UI_Canvas_Manager` |

The first two and `CharacterController` already exist in the template. The other four are **planned, not yet written**. Full tables (variables, functions, packages) are in `index.html` and `Requirements/work.json`.

---

## 6. Pipeline (AAA framework)

1. **Application** — shallow project folder, template project, confirm it runs.
2. **Action** — import NaN (Mixamo, Humanoid rig), swap it into `PlayerArmature`.
3. **Action** — modular ward prefabs (walls, floors, doors, colliders, fog).
4. **Amplification** — `StimulusItem` + `RoomStabilizer` + first Static audio cue.
5. **Amplification** — playtest: zero console errors, stable frame rate.

Boards: [`Resources/boards/pipelineBoard.png`](Resources/boards/pipelineBoard.png) · [`huddleBoard.png`](Resources/boards/huddleBoard.png) · [`prepBoard.png`](Resources/boards/prepBoard.png) · [`reportABoard.png`](Resources/boards/reportABoard.png)

---

## 7. Status (honest checkpoint, 2026-11-12)

| Area | State |
|---|---|
| Written prep, pitch, AI plan, huddle, tables | ✅ done (`Context/notes.md`, `index.html`) |
| Issued records (PREP + 3 FORM PDFs) | ✅ in `Requirements/issued-pdfs/` |
| Unity project created, opens, **runs in Play mode** | ✅ screenshot in `Evidence/` |
| Third-person player works | ✅ template robot player visible and controllable in the evidence screenshot |
| Console result | ⚠️ 0 errors, **1 warning**: *"ScriptableRuntimeReflectionSystemSettings.system is assigned more than once"* (HDRP template warning, harmless, from the template) |
| Failure → fix → retest | ⬜ no failure occurred yet; first expected at the NaN import |
| NaN character import (Mixamo, Humanoid) | ⬜ not started |
| Custom ward prefabs | ⬜ not started (`Assets/StimuLye/Prefabs/` is empty) |
| `StimulusItem` / `RoomStabilizer` scripts | ⬜ not started |
| Static audio cue, playtest, FPS measurement | ⬜ not started |
| Task checkboxes in `work.json` (Documentation, Setup, Player import, Testing, Handoff) | ⬜ still unchecked on the course site |

---

## 8. Submission checklist

- [ ] Repo is pushed and public: `Lexicon-Lexxie/CS110-Lexxie` → `Week12/12B/`
- [ ] Canvas submission contains the **repo URL** and **`VIEW-9265F91D9B43EF8355AB19A9`**
- [ ] Same name + code in the Canvas submission comment
- [ ] `PERSONAL-SUBMISSION-CODE.txt` is in the folder (it is, at the root)
- [ ] **No private recovery key** anywhere in the repo (checked: none found)
- [ ] Each task result on the course site refers to real saved files/tests (use paths from §2 and §3)

---

## 9. Things to know / known mismatches

1. **HDRP vs URP.** Earlier planning notes and the C# package table say *URP* (`UnityEngine.Rendering.Universal`). The project actually uses **HDRP** (High Definition 3D template). Either update the docs to say HDRP, or switch the project to URP before building. HDRP is heavier, so check frame rate on lower-end machines.
2. **Project name** inside Unity is `DangerousGame` (template default). Rename in *Edit → Project Settings → Player → Product Name* when convenient. It does not affect the folder name.
3. **Repository size.** The Unity project is about 250 MB, mostly template baked lighting. The two biggest files (`Lightmap-0_comp_light.exr` ≈ 27 MB and `Lightmap-1_comp_light.exr` ≈ 23 MB) are under GitHub's 100 MB per-file limit, so plain Git works. If you add large models or audio, use Git LFS.
4. **Template folder is not mine.** `SampleSceneAssets/` and `Scenes/SampleScene*` come from Unity's HDRP template; credit Unity in any write-up.
5. **`.meta` files must stay with their assets.** Never move assets outside the Unity Editor once you are working in `Assets/`.
6. **Report links.** `index.html` links to `Requirements/…` and `project-source/…`. If you move those folders, the links break.

---

## 10. What changed in this reorganization

| Before | After |
|---|---|
| `UnityProject/` (root) | `project-source/UnityProject/` |
| `notes.md`, `Terms.md`, `availability.ics`, `README.txt` (root) | `Context/` (`README.txt` → `Course-README.txt`) |
| `issued-pdfs/`, `Working-Draft.pdf`, `work.json`, `prefs.json` (root) | `Requirements/` |
| `boards/` | `Resources/boards/` |
| `FORM-9A9193840307A5B39A239303.pdf` (root) | removed: duplicate of `Requirements/issued-pdfs/FORM-9A9193840307A5B39A239303.pdf` (identical text) |
| — | new: `README.md`, `.gitignore`, `Assets/StimuLye/` skeleton |
| `index.html` links | updated to the new paths (all 8 verified) |

No file inside the Unity project was edited or moved, so GUID references and `.meta` files are intact.
