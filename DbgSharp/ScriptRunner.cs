using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace DbgSharp;

/// <summary>
/// Provides methods to interpret C# scripts
/// </summary>
public static class ScriptRunner
{
    /// <summary>
    /// Interprets the C# script
    /// </summary>
    /// <param name="script">
    /// Input code
    /// </param>
    /// <returns>
    /// Script state, which can then be modified or debugged
    /// </returns>
    public static ScriptState<dynamic> Run(string script)
    {
        return CSharpScript.RunAsync(script).Result;
    }

    /// <summary>
    /// Interprets the C# script asynchronously
    /// </summary>
    /// <param name="input">
    /// Input code
    /// </param>
    /// <returns>
    /// Script state, which can then be modified or debugged
    /// </returns>
    public static async Task<ScriptState<dynamic>> RunAsync(string input)
    {
        return await CSharpScript.RunAsync(input);
    }

    /// <summary>
    /// Attempts to run the C# script and gives a bit more
    /// detailed error in case of an exception.
    /// </summary>
    /// <param name="script">
    /// Input code
    /// </param>
    /// <returns>
    /// Script state, which can then be modified or debugged
    /// </returns>
    /// <exception cref="ArgumentException">
    /// A slightly more detailed exception if an exception occurred
    /// during interpretation
    /// </exception>
    public static ScriptState<dynamic> TryRun(string script)
    {
        try
        {
            return Run(script);
        }
        catch (Exception ex)
        {
            throw new ArgumentException("ScriptExecError".Resource() + $"\n{ex}");
        }
    }

    /// <summary>
    /// Attempts to run the C# script asynchronously and
    /// gives a bit more detailed error in case of an exception.
    /// </summary>
    /// <param name="script">
    /// Input code
    /// </param>
    /// <returns>
    /// Script state, which can then be modified or debugged
    /// </returns>
    /// <exception cref="ArgumentException">
    /// A slightly more detailed exception if an exception occurred
    /// during interpretation
    /// </exception>
    public static async Task<ScriptState<dynamic>> TryRunAsync(string input)
    {
        try
        {
            return await RunAsync(input);
        }
        catch (Exception ex)
        {
            throw new ArgumentException("ScriptExecError".Resource() + $"\n{ex}");
        }
    }
}
