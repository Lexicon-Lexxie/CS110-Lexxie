# CS110 / Action 10B / Three Hello World Investigations

Current phase: independent study with teams and tools.

## My transfer note / saved in the same README

Stayed the same: The core domain class and logic: the Greeting class, the Name property, and the BuildMessage() method returning the formatted string remain identical across all three environments.

Changed (trigger/output/API): 
- Console: Triggered on startup; output via Console.WriteLine().
- WPF: Triggered by user interaction (SayHello_Click event); output by setting the UI property MessageText.Text.
- Engine: Triggered by engine lifecycle callback (Start() in Unity or _Ready() in Godot); output via Debug.Log() or GD.Print().

Evidence: Whiteboard diagram mapping class -> object -> method -> output, along with output screenshots saved in Evidence/ (console-output.png, wpf-window.png, engine-output.png).

For A1 I could use this to: Decouple underlying game state, rules, and inventory data from presentation, allowing the same logic to power 2D UI panels, 3D world prompts, and debug logs without rewriting code.

## Lecture investigation notes

Three concepts: 
1. A class defines a type blueprint; 'new' instantiates an object holding reference data.
2. Separation of concerns: business logic (Greeting) remains static while presentation adapts to the host environment.
3. Execution lifecycle: Console runs procedural Main, WPF relies on event-driven handlers (Click), and engines rely on lifecycle loops (Start / _Ready).

One question: How does XAML's partial class mechanism compile and link x:Name controls to C# code-behind fields without manual instantiation?

Whiteboard / Discord check / my contribution: Drew diagram mapping class (Greeting) -> object (greeting) -> method (BuildMessage) -> output. Verified with peer check on Discord. Coordinated Git repository and engine build.

Prediction: Instantiating Greeting with Name = "Ari" and calling BuildMessage() will output "Hello, world, Ari!" across all three environments without altering Greeting.cs.

What I tried: Created shared Greeting.cs under HelloInvestigation namespace. Executed callers in Console Main(), WPF SayHello_Click handler, and Unity/Godot lifecycle script.

Result / error: All three environments produced the expected string "Hello, world, Ari!" in their respective output streams without compiler errors.

What it means / next step: Confirmed pure C# domain classes are host-agnostic. Next step: assemble screenshots and the 10b receipt into the Evidence/ folder.

Evidence file/link: Evidence/whiteboard.png, Evidence/console-run.png, Evidence/wpf-run.png, Evidence/engine-run.png

## Console investigation notes

Prediction: I thought the program would display a greeting message in the console using the name Ari.

What I tried: I created a Greeting class in Greeting.cs, made a new Greeting object in Program.cs, and called the BuildMessage() method.

Result / error: At first, I got an error saying the Greeting type or namespace could not be found. I needed to make sure Greeting.cs was included in the same project as Program.cs.

What it means / next step: The Greeting class stores a name, and BuildMessage() returns a string containing the greeting. Console.WriteLine() displays the message. My next step is to fix any errors, run the program, and check the output.

Evidence file/link: Screenshot of the console output showing "Hello, world, Ari!" and the Greeting.cs and Program.cs source files.

AI RESPONSE
•	Greeting is defined in ..\Greetings.cs.
•	The project includes it through the linked compile item in week10console.csproj.
•	Program.cs creates a Greeting object using "Ari".
•	BuildMessage() returns "Hello, world, Ari!".
•	Console.WriteLine() displays the result.

## XAML / WPF investigation notes

XAML creates the window's visual layout, including the text blocks and the "Say Hello" button.

C# handles the button click.

Prediction:  When I click the button "Say Hello," the window will display "Hello, Ari!" 

What I tried:  Created the WPF window in XAML 

Result: The XAML layout is complete. I ran it and the output was a button that returned "Hello, Ari!"

XAML controls how the window looks, while C# controls what happens when the button is clicked.

## Engine investigation notes

Engine / version / language: Unity 2022.3 LTS (or Unity 6) / C# / .NET Standard 2.1

Official setup + scripting links: 
- Unity Scripting Architecture: https://docs.unity3d.com/Manual/ScriptingSection.html
- MonoBehaviour.Start API: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
- Debug.Log API: https://docs.unity3d.com/ScriptReference/Debug.Log.html

Object / script / callback: GameObject 'Beacon' (3D Cube at 0,0,0) with HelloWorld.cs attached as a component. Callback used is Start(), invoked automatically by the engine on the first frame of Play mode.

AI question -> source check -> test -> decision:
- Question / Supplied verification: Verified how an attached MonoBehaviour interacts with a plain C# domain class and engine callbacks.
- Source check: Confirmed in Unity ScriptReference that MonoBehaviour.Start() runs once before the first frame update and Debug.Log() routes directly to the Unity Editor Console.
- Test: Attached HelloWorld.cs to Beacon in the active scene and entered Play mode.
- Decision: KEEP. Plain C# classes (Greeting) require no MonoBehaviour inheritance, but caller components must inherit from MonoBehaviour to participate in Unity's scene lifecycle.

Prediction: Entering Play mode will cause Unity's engine loop to invoke Start() on the active Beacon GameObject, instantiating Greeting and logging "Hello, world, Ari!" to the Unity Console.

What I tried: Created 3D project under EngineTrial/, created Beacon cube at (0,0,0), placed Greeting.cs in Assets/Scripts/, attached HelloWorld.cs to Beacon, and opened the Console window.

Result / error: The script executed cleanly upon entering Play mode. The message "Hello, world, Ari!" printed to the Console window at timestamp 0.0s with no compilation errors.

What it means / next step: Confirms that plain C# business logic from Console and WPF runs in Unity without modification when invoked through Unity's component lifecycle. Next step: commit the project and screenshot to GitHub.

Evidence file/link: Evidence/engine-unity.png

## Working arrangement
Group
Lead: Lexxie
Members / contributions: Lexxie - Lead, Git coordinator & Engine build
Rudy - Console implementation & AI verification
Paulina - WPF / XAML implementation & code review
Sam - Whiteboard diagram
Nico - Evidence documentation
Task | Owner | Status:
Task | Owner | Status
Console Hello World | Paulina | Completed
WPF / XAML Window | Rudy | Completed
Game Engine Attempt | Lexxie | Completed
Whiteboard & Peer Check | Sam | Completed
README & Receipt Integration | Lexxie | Completed



## My handoff
GitHub: https://github.com/Lexicon-Lexxie/cs110-week10/
Required: Console/, WPF/, EngineTrial/, Evidence/ and cs110-10b-receipt.txt.
Canvas: https://sbccd.instructure.com/courses/66804/assignments/1913888
This record does not verify submission or grading.
