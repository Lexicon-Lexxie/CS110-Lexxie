### 1. The Core Coding Tasks (The 3 Builds)

Every build uses the same core class logic:
```csharp
namespace HelloInvestigation
{
    public class Greeting
    {
        public string Name { get; set; } = "runner";
        public string BuildMessage() => $"Hello, world, {Name}!";
    }
}
```

#### Build 1: Console App (`Console/`)
* **Project:** C# Console App named `HelloConsole`.
* **Action:** Include `Greeting.cs`. In `Program.cs`, instantiate `Greeting`, set `greeting.Name = "Ari"`, and print using `Console.WriteLine(greeting.BuildMessage());`.
* **Evidence:** Screenshot of the working terminal output (`Hello, world, Ari!`).

---

#### Build 2: WPF App (`WPF/`)
* **Project:** C# WPF Application named `HelloWpf`.
* **Action:** 
  * In `MainWindow.xaml`: Create a layout with a `StackPanel`, two `TextBlock`s (one named `MessageText`), and a `Button` (named `HelloButton`, with `Click="SayHello_Click"`).
  * In `MainWindow.xaml.cs`: In `SayHello_Click`, instantiate `Greeting`, set `.Name = "Ari"`, and assign `MessageText.Text = greeting.BuildMessage();`.
* **Evidence:** Screenshot of the window after clicking the "Say Hello" button.

---

#### Build 3: Game Engine Attempt (`EngineTrial/`)
*(Pick **one**: Unity or Godot. A documented attempt/error is acceptable if you run into setup barriers!)*

* **Option A: Unity (3D)**
  * Add a 3D Cube named `Beacon` at `(0,0,0)`.
  * Add `Greeting.cs` and a script `HelloWorld.cs` (inherits `MonoBehaviour`) in `Assets/Scripts/`.
  * In `Start()`, instantiate `Greeting` and log via `Debug.Log(greeting.BuildMessage());`.
  * Attach the script to `Beacon` and enter Play mode.
* **Option B: Godot (.NET)**
  * Create a 2D scene with a `Sprite2D` node named `Beacon` at position `(160, 120)` with an icon texture.
  * Attach a C# script `HelloWorld.cs` (inherits `Sprite2D`).
  * In `_Ready()`, instantiate `Greeting` and print via `GD.Print(greeting.BuildMessage());`.
* **Evidence:** Screenshot of the editor showing the scene hierarchy, the attached script on `Beacon`, and the output message in the engine console/output log (or screenshot of exact error if blocked).

---

### 2. What Goes into the `README.md`
You need **one README** covering four entries plus reflection:

1. **Lecture Notes & Planning (R1):**
   * 3 concepts learned from the lecture.
   * 1 prediction & 1 question.
   * Visual/Whiteboard photo showing: `class -> object -> method -> output` (mapping visual hat, logical hat, and data hat) + Discord peer check note.
   * If in a group: team lead, member list, task table (`Task | Owner | Status`), and your individual contribution.
2. **Console Entry (R2):**
   * Predict -> Observe -> Explain.
   * Screenshot of console output.
3. **WPF Entry (R3):**
   * Predict -> Observe -> Explain (explain XAML vs. C# code-behind).
   * Screenshot of running WPF window.
4. **Engine Entry (R4):**
   * Engine version, setup notes, script connection.
   * Screenshot of engine output (or exact error and your next diagnostic step).
   * **Required AI check:** Run the prompt from Page 8 (or verify the provided response on Page 8), check an official documentation link, and state whether you keep/change/reject the suggestion.
5. **Cycle Map Summary (Page 10):**
   * Four brief reflection lines:
     * *What stayed the same?* (The `Greeting` class logic/data)
     * *What changed?* (The trigger and the output method: `WriteLine` vs UI Text vs Engine Log)
     * *What evidence shows it?*
     * *Where could you use this in A1?*

---

### 3. Required GitHub Repository Structure

Ensure your repository is organized cleanly before pushing:

```text
your-repo-name/
├── Console/           <-- Editable C# Console project files
├── WPF/               <-- Editable WPF project files
├── EngineTrial/       <-- Unity or Godot project files / scripts
├── Evidence/          <-- All screenshots, whiteboard photo, and cs110-10b-receipt.txt
└── README.md          <-- Complete investigation notes
```

> **Note:** Make sure to use a `.gitignore` so you do **not** commit `bin/`, `obj/`, build caches, or engine library/temp folders.

---

### 4. Submission Checklist

1. [ ] Download the receipt template `cs110-10b-receipt.txt` and place it inside `Evidence/`.
2. [ ] Commit and push all folders (`Console/`, `WPF/`, `EngineTrial/`, `Evidence/`, `README.md`) to GitHub.
3. [ ] Verify your instructor has access to your repository (public repo or instructor invited as collaborator).
4. [ ] Submit your **GitHub repository URL** to the Canvas assignment.
