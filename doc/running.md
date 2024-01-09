Use the `ScriptRunner` class found in the `DbgSharp` namespace to run C# scripts. These methods only call `Microsoft.CodeAnalysis.CSharp.Scripting.CSharpScript.RunAsync<T>(String)` methods, so you may not find much useful from them.

# Microsoft.CodeAnalysis.CSharp.Scripting.ScriptState&lt;dynamic&gt; DbgSharp.ScriptRunner.Run(String)
Runs the C# script.

#### Parameters:
1. Input code to interpret (type `String`)

# Microsoft.CodeAnalysis.CSharp.Scripting.ScriptState&lt;dynamic&gt; DbgSharp.ScriptRunner.RunAsync(String)
Runs the C# script asynchronously.

#### Parameters:
1. Input code to interpret (type `String`)

# Microsoft.CodeAnalysis.CSharp.Scripting.ScriptState&lt;dynamic&gt; DbgSharp.ScriptRunner.TryRun(String)
Runs the C# script and throws a bit more detailed (and multilingual) exception on failure.

#### Parameters:
1. Input code to interpret (type `String`)

# Microsoft.CodeAnalysis.CSharp.Scripting.ScriptState&lt;dynamic&gt; DbgSharp.ScriptRunner.TryRunAsync(String)
Runs the C# script asynchronously and throws a bit more detailed (and multilingual) exception on failure.

#### Parameters:
1. Input code to interpret (type `String`)
