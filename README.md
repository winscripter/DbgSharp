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

