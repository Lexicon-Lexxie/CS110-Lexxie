# CS110 Action 11A — My seminar and engine experiment

Learner / folder: Lexxie (Lexicon-Lexxie)
Engine route: unity
Work mode: team
My personal repository / one Canvas submission link: https://github.com/Lexicon-Lexxie/CS110-Lexxie
Team repository: https://github.com/Lexicon-Lexxie/CS110-Awayzo

## GitHub checks before and after work

- Before work, local project / remote / latest push checked: Checked and working: opened my local CS110 folder, remote is github.com/Lexicon-Lexxie/CS110-Lexxie.
- Personal repository URL and file/image/link check result: Checked and working: GitHub shows my latest files.
- Team repository / member links checked: Checked and working: team repo https://github.com/Lexicon-Lexxie/CS110-Awayzo.
- Final push and instructor-access check result: Final push done to https://github.com/Lexicon-Lexxie/CS110-Lexxie/tree/main/Week11/11A. Opened the repo in a private browser window and it works.

## 1. Our Attention Accord — shared plan/reference

- Huddle start / end (at least 10 minutes): 2:00 PM to 2:30 PM (30 minutes)
- Team / lead / production purpose: Team Awayzo (Lexxie, Nico, Paulina, Rudy, Sam). Lexxie leads. Before we build our game, we need to understand how a class becomes engine behavior, how values reach the visible object, and how reusable setups differ from live instances. Each person investigates one piece and returns evidence we use to choose our movement and object-setup approach.
- Plan file, board photo or shared-document link: https://github.com/Lexicon-Lexxie/CS110-Lexxie/blob/main/Week11/11A/Evidence/Whiteboard/whiteboard-01-team-accord.jpg (team board photo, copy saved at `Week11/11A/Evidence/Whiteboard/`).
- Return-to-team time and how we will use the findings: Return to the team at 2:40 PM. We choose our movement behavior from Lexxie's and Paulina's findings, our setup approach from Sam's and Rudy's, and our extension ideas from Nico's boundary and Rudy's jump tests.

| Member | Focus question | Capture method | Promised contribution |
|---|---|---|---|
| Lexxie (lead, Git) | Who calls `Update`, and how does `Time.deltaTime` turn a rate into this frame's motion? | Annotated copy of TranslateObject; Speed 0/1/2 test log | Annotated example, prediction vs. result, recommendation for our movement behavior; repo structure and team repo access check |
| Nico (whiteboard, prototype) | How does a class become engine behavior, and how do values reach the visible object? | Whiteboard sketch: class → object → data/property → method → visible result | Whiteboard photos before and after revision; prototype idea for the team |
| Paulina (evidence, review) | Why does changing Tint after `Start` not reapply it, and why does the Inspector not call the setter? | Test notes, screenshots, evidence checklist | Explanation with proof, a mistake investigated, team index of everyone's links |
| Rudy (bounded AI check, QA) | What does an AI answer about one engine API get right or wrong against official docs and my test? | Question log: question, checked source, keep/change/reject | The log, plus correction of the false claim that a prefab means extra instances use no runtime memory |
| Sam (reuse and physics) | How do prefabs, live instances and pooling differ, and what does each cost? | Prefab vs. instance vs. pooling guide; small physics test on a copy | Guide, two-instance comparison, Transform vs. physics trap note |

These are focus areas for this assignment, not ranks or permanent roles. We rotate them in later work.

## My personal attention brief

- I will investigate: Who calls `Update` and how `Time.deltaTime` turns a per-second rate into this frame's change, using `TranslateObject`.
- I need to understand: Whether prefab instances use extra runtime memory, since the lecture and the assignment describe it differently, and how `Update` with `Time.deltaTime` behaves when I add keyboard input to `TranslateObject`.
- I will capture: An annotated copy of TranslateObject, a Speed 0 / 1 / 2 test log with predictions, and screenshots.
- I will return with: An annotated example, my prediction and result, a mistake I investigated, and a recommendation for our movement behavior.
- My evidence will be saved at: `11A/Evidence/BaseTests/` and `11A/Evidence/Extension/` in my personal repository.
- How this helps our team build: We will use the finding to choose the movement behavior for our game, and I will check that every member's contribution has an owner and can be found.

## 2. My seminar notes

- Class and object in my own words: A class is a blueprint that says how something is created. Inside it are containers (variables) and actions (functions) that hold the logic. An object is the thing actually created from that blueprint, and every object-oriented language follows this. In Unity everything in the scene is an object, so I plan a game by starting from classes, not from loose variables or functions.
- One field/property and one method: In `TranslateObject`, `speed` is the private field, `Speed` is the property (get/set) that gives outside code controlled access to it, and `Update()` is the method that runs every frame. The lecture stressed that properties protect variables by giving outside code access without exposing the field directly.
- Why `transform` is lowercase: Inside a script it is a member of the class itself, as if written `this.transform`. `this` is a C# keyword, so `transform.Translate(...)` means "take the object this script is on, get its Transform class, and run its Translate action." Unity's authors followed object-oriented conventions, so C# knowledge explains the engine's code.
- Mindset from the lecture: Every engine has different words, but all of them rest on the same base (hardware and binary, then OS, then runtime, then classes), so when something is new I map it back to what I already know.
- Claim to verify: The lecture described prefabs as "only one exists in the game and the others just reference it." The assignment says live instances still use runtime memory and a prefab does not automatically prevent memory growth. I will check the official Unity prefab and object pooling references and keep the assignment's version in my R4 explanation.
- My question coming into the seminar: What exactly is a prefab, and does making many instances of one save memory?

## My host translation

- Engine / version / language: Unity 6.6 (6000.6.7f1), C#
- Familiar C# idea → engine equivalent: The Visual Studio WPF view, code-behind view and debug output map to Unity's Scene/Game view, the properties (Inspector) panel and the debug Console. A class with fields and methods → a script attached to a GameObject as a component. Dragging a button in WPF → dragging a script onto the object. Visual Studio itself still edits the C#.
- Familiar idea, data → action → trigger → result: `speed` / `degreesPerSecond` / `tint` (data) → `Translate`, `Rotate`, set `.color` (actions) → `Update` every frame and `Start` once (triggers) → the cube moves, turns and changes color on screen.
- Who calls initialization and repeated updates? The engine. Visual Studio has no built-in game loop, but Unity is built around one: it calls `Start` once and `Update` every frame for an enabled component, and `Time.deltaTime` converts a rate per second into this frame's change.
- One discovery I shared with the team: `transform` is lowercase because it is a member of the class itself (`this.transform`), so C# knowledge explains Unity's code. I also flagged that the lecture's prefab-memory description needs checking against the official docs.

## 3. My individual base

- My source files / scene: `11A/EngineProject/`, scene `EngineTransfer11A`, scripts in `Assets/Scripts/EngineTransfer11A/` (TranslateObject, RotateObject, ChangeObjectColor), cube `MyMarker`.
- Starting values and prediction: Speed 1, DegreesPerSecond 90, Tint cyan. My prediction: at Speed 0 the cube will stay in place but keep rotating and stay cyan, since rotation and color are separate scripts; at Speed 2 it will drift right about twice as fast while turning at the same rate. I wonder whether changing Tint while stopped will show the new color when I press Play, since the color is only applied once in `Start`.
- Actual movement / rotation / color result: The cube shows cyan in the Game view at startup (`Evidence/BaseTests/base-01-cube-cyan-startup.png`, Unity 6.6, scene EngineTransfer11A, MyMarker in the Hierarchy). The base ran as expected: the cube moved, rotated and kept its startup color at Speed 1, and Speed 0 and Speed 2 behaved as I predicted.
- The class/property/method responsible: Movement is `TranslateObject.Update()` reading `Speed`; rotation is `RotateObject.Update()` reading `DegreesPerSecond`; color is `ChangeObjectColor.Start()` applying `Tint`.
- Frustration or error, and how I investigated: The part that confused me most was making the prefab. I worked through it and it ended successfully, and all of my test results were successful.

## 4. My experiment and return to the team

- My question / prediction: Can the cube be moved with the keyboard instead of only a constant Speed? My prediction: if I read an input value and multiply it with `Speed` and `Time.deltaTime` in `Update`, the cube will respond to the arrow keys and stay still when no key is pressed. I wonder whether it will still feel smooth at different frame rates.
- Change beyond the base: Keyboard input control on `TranslateObject` (made on a copy or after a Git checkpoint). Added a `KeyboardMove` script (Input System, arrow keys/WASD) to MyMarker and turned off TranslateObject while testing, then turned it back on.
- Observed result or exact error / next step: The keyboard control ran as expected and the cube responded to key presses (`Evidence/Extension/extension-01-keyboard-input.png`).
- Prefab or saved scene and two-instance comparison: Saved MyMarker as a prefab, placed a second instance with an offset position, and changed only its Speed. The two instances ran as expected, each keeping its own Speed while sharing the same prefab setup. Evidence: `Evidence/BaseTests/prefab-01-two-instances.png`.
- Why a template does not solve memory growth: A prefab stores a configured setup, but every live instance uses runtime memory and can add per-frame CPU/GPU work. Lifetime rules remove instances and pooling reuses a bounded set; saving a prefab does neither. So "a prefab means any number of bullet instances use no extra runtime memory" is incorrect.
- What I promised → what I actually returned: I promised an annotated look at how `Update` and `Time.deltaTime` drive movement, with a prediction and a result. I returned my Speed predictions and results, a working base, a prefab test and a keyboard extension, all successful.
- My interpretation/recommendation and supporting evidence: Interpretation (my opinion): I think we should use rate times `Time.deltaTime` for our game's movement, because it ties motion to elapsed time instead of frame count, and I think keeping move, turn and color in separate scripts will make each one easier to test and reuse. My Speed 2 test ran as predicted, which supports this.
- How the team will use it: We plan to build our movement behavior from this deltaTime approach and use my notes as the team's reference for how the base fits together.
- What I learned from someone else: A teammate showed me how they upload their work to GitHub.
- Checked source or supplied-claim correction: Unity Manual, "Introduction to prefabs" (https://docs.unity.com/en-us/engine/6000.7/manual/working-with-gameobjects/prefabs/introduction). It says a prefab asset is used to create prefab instances in a scene and that individual instances can override settings, such as a robot's movement speed, which matches my two-instance test. It describes reuse and syncing, not saving memory, so "a prefab means any number of instances use no extra runtime memory" is not supported. Object pooling reuses a bounded set of objects instead of creating and destroying new ones.

## Source and evidence

Project: `11A/EngineProject/`. Whiteboard: `11A/Evidence/Whiteboard/`. Base tests: `11A/Evidence/BaseTests/`. Extension: `11A/Evidence/Extension/`. Preparation receipt: `11A/preparation-receipt.json`. Board photo: https://github.com/Lexicon-Lexxie/CS110-Lexxie/blob/main/Week11/11A/Evidence/Whiteboard/whiteboard-01-team-accord.jpg. Checked source: Unity Manual, "Introduction to prefabs" (https://docs.unity.com/en-us/engine/6000.7/manual/working-with-gameobjects/prefabs/introduction).

My individual engine base status: working.
My individual extension status: working, keyboard input ran as expected.
Help received: [describe].

Commit and push all my authored work, including board captures, notes, project and evidence, to my personal repository. Open the pushed files/images and test the personal URL and applicable team URL/member links. Submit the one personal repository URL in Canvas; this README contains the team link if applicable. This export is not Canvas submission.
