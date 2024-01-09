using Microsoft.CodeAnalysis.Scripting;

namespace DbgSharp;

/// <summary>
/// Contains implementations for a debugger engine
/// </summary>
public interface IDebuggerEngine
{
    /// <summary>
    /// Indicates that the current program or script is paused.
    /// This can also be seen when a breakpoint was triggered.
    /// </summary>
    bool Paused { get; set; }

    /// <summary>
    /// Line numbers containing breakpoints, e.g. where to stop at.
    /// If the breakpoint goes out of bounds of the source file (line of code
    /// is bigger than amount the source file has), it will not be read.
    /// </summary>
    HashSet<int> Breakpoints { get; set; }

    /// <summary>
    /// Pauses the script and allows examining the variables.
    /// </summary>
    void Pause();

    /// <summary>
    /// Returns a list of variables from the current script. The debugger
    /// must be paused or hit the breakpoint in order to use this method.
    /// </summary>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> of type <see cref="Variable"/>, representing all variables
    /// from the current script.
    /// </returns>
    IEnumerable<Variable> ExamineVariables();

    /// <summary>
    /// Returns the environment - that is, where the actual code is ran. This is
    /// also known as Script State.
    /// </summary>
    ScriptState<dynamic> GetEnvironment();

    /// <summary>
    /// Returns the current line being executed or paused on.
    /// </summary>
    int Line { get; }

    /// <summary>
    /// Starts the debugger asynchronously. This method does nothing if
    /// the debugger is already started.
    /// </summary>
    void DebugAsync();

    /// <summary>
    /// Stops the debugger.
    /// </summary>
    void Stop();

    /// <summary>
    /// Gets the source code that will be debugged
    /// </summary>
    string Source { get; set; }

    /// <summary>
    /// Indicates that the debugger stopped because an exception
    /// was caught.
    /// </summary>
    bool ExceptionCaught { get; set; }

    /// <summary>
    /// Gets the uncaught exception. This is null if no exception
    /// occurred or it was catched.
    /// </summary>
    Exception? CaughtException { get; set; }

    /// <summary>
    /// Indicates that the script is currently
    /// being debugged.
    /// </summary>
    bool Running { get; set; }
}
