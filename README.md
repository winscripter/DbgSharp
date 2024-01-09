# DbgSharp: A C# Script Debugger with C#
Use `DbgSharp` when you need to run, interpret, or specifically, the main purpose of this library, **debug** scripts.
DbgSharp does not attach a debugger to a running process - instead, it interprets the input code line-by-line until there's
a breakpoint. This is all done thanks to the powers of [Roslyn Compiler APIs](https://github.com/dotnet/roslyn), so before
building a project, you'd have to install `Microsoft.CodeAnalysis.CSharp` and `Microsoft.CodeAnalysis.CSharp.Scripting` NuGet
packages.
