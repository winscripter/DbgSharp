Main purpose of this library - debugging C# scripts and examining its variables is possible with the `DebugEngine` class that implements `DbgSharp.IDebuggerEngine` interface. This class can be found in the `DbgSharp` namespace. This class cannot be inherited.

# DebugEngine(String)
Sets input code without breakpoints.

#### Parameters:
1. Input code (type `String`)

# DebugEngine(Int32[], String)
Sets input code and breakpoints.

#### Parameters:
1. Breakpoints (which lines to stop at - 1?) (type `Int32[]`)
2. Input code (type `String`)

# async void DebugAsync()
Debugs given C# code asynchronously. If there are any breakpoints, stops on the first breakpoint.

# void Pause()
Pauses the debugger, as if it was a breakpoint. The debugger may need some time to respond if it's interpreting a line of code that takes a long time to complete.

# void Stop()
Stops the debugger. The debugger may need some time to respond if it's interpreting a line of code that takes a long time to complete.

# Microsoft.CodeAnalysis.CSharp.Scripting.ScriptState&lt;dynamic&gt; GetEnvironment()
Gets the Script State used by the debugger,

# System.Collections.IEnumerable&lt;DbgSharp.Variable&gt; ExamineVariables()
Returns variables from the C# script if the breakpoint was hit or the debugger is paused.

