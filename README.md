# DbgSharp: A C# Script Debugger with C#
Use `DbgSharp` when you need to run, interpret, or specifically, the main purpose of this library, **debug** scripts.
DbgSharp does not attach a debugger to a running process - instead, it interprets the input code line-by-line until there's
a breakpoint. This is all done thanks to the powers of [Roslyn Compiler APIs](https://github.com/dotnet/roslyn), so before
building a project, you'd have to install `Microsoft.CodeAnalysis.CSharp` and `Microsoft.CodeAnalysis.CSharp.Scripting` NuGet
packages.

### Running C# scripts

The `ScriptRunner` class takes a single method invocation to the Roslyn Scripting APIs.
To run a C# script, use:
```cs
const string inputCode = "Console.WriteLine(\"Hello from DbgSharp!\");";
ScriptRunner.Run(inputCode);
```
To run a C# script asynchronously, use:
```cs
const string inputCode = "Console.WriteLine(\"Hello from DbgSharp!\");";
await ScriptRunner.RunAsync(inputCode);
```
ScriptRunner really just calls one method from Roslyn Scripting APIs, so instead, if
you use Roslyn Scripting APIs (Microsoft.CodeAnalysis.CSharp.Scripting), you can manually
call one of the methods from the Roslyn Scripting APIs to accomplish this task. For example,
to run a C# script, use:
```cs
const string inputCode = "Console.WriteLine(\"Hello from DbgSharp!\");";
Microsoft.CodeAnalysis.CSharp.Scripting.CSharpScript.RunAsync(inputCode);
```
Or, to run the C# script asynchronously, use:
```cs
const string inputCode = "Console.WriteLine(\"Hello from DbgSharp!\");";
await Microsoft.CodeAnalysis.CSharp.Scripting.CSharpScript.RunAsync(inputCode);
```

### Interpreting C# scripts
You can also interpret C# scripts by adding a new line and interpreting right away.
This can help you build interpreters with C#.

First, you need to instantiate the `Interpreter` class:
```cs
var interpreter = new Interpreter();
```

The `Interpret(String)` method of the `Interpreter` class interprets an additional
line of given C# code. F.E.:
```cs
interpreter.Interpret("int x = 45;");
interpreter.Interpret("System.Console.WriteLine(x);"); // outputs 45
```

### Debugging C# scripts
As the main purpose of this library, you can also debug C# scripts.
This is all done with the `DebugEngine` class, which implements `DbgSharp.IDebuggerEngine`.

`DebugEngine` can take two possible constructors:
<ul>
  <li>
    <code>
      DebugEngine(String)
    </code>
    - Takes input code and interprets it
  </li>
  <li>
    <code>
      DebugEngine(Int32[], String)
    </code>
    - Takes breakpoints as array of `int`, which tell at
    which line should breakpoints be triggered, and input
    code as the 2nd parameter.
  </li>
</ul>

The `DebugEngine.DebugAsync()` asynchronous method begins the debugging process. If
you have breakpoints, `DebugEngine` will stop at the first breakpoint seen.

Here's a simple example. We can use `DebugEngine` to break at line 2 (LoC indexes start with 0)
and then inspect variables using the `DebugEngine.ExamineVariables()` method.

```cs
var breakpointLines = new[] { 1 }; // breakpoint at line 2
string inputCode = @"int x = 20;
int y = 25;
System.Console.WriteLine(x + y);
";
var engine = new DebugEngine(breakpointLines, inputCode);
engine.DebugAsync(); // stops at line 2

foreach (var variable in engine.ExamineVariables())
{
    Console.WriteLine($"Name: {variable.Name}");
    Console.WriteLine($"Value: {variable.Value}");
}
```
The code above should produce the following output:
```cs
Name: x
Value: 20
```
Oh, look at that. Where's our `y` variable?
That's how DbgSharp works. When you add a breakpoint, instead of interpreting
that line, the debugger just stops right away and allows debugging possible.

# This is the first version
And thus, DbgSharp has appeared somewhere on the internet, on January 9 2024!
Is it going to be popular? Or not? I don't care. At least someone might need it. :)
