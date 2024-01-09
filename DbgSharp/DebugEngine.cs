using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.Diagnostics;

namespace DbgSharp;

/// <summary>
/// DbgSharp's Main Debugger Engine - used for debugging C# code.
/// This class cannot be inherited.
/// </summary>
public sealed class DebugEngine : IDebuggerEngine
{
    public bool Paused { get; set; } = false;

    public HashSet<int> Breakpoints { get; set; } = new();

    public string Source { get; set; } = string.Empty;

    private ScriptState<dynamic>? State { get; set; }

    public bool ExceptionCaught { get; set; } = false;

    public Exception? CaughtException { get; set; } = null;

    public bool Running { get; set; } = false;

    public DebugEngine(string source)
    {
        Source = source;
    }

    public DebugEngine(int[] breakpoints, string source)
        : this(source)
    {
        Array.Sort(breakpoints);
        Breakpoints = new(breakpoints);
    }

    public int Line { get; set; } = 0;

    public async void DebugAsync()
    {
        if (Running)
        {
            return;
        }

        Running = true;

        ScriptState<dynamic>? s = null;

        if (State is not null)
        {
            s = State;
            for (int i = Line; i < Source.Length; i++)
            {
                Line = i;
                if (!Running || Paused)
                {
                    State = s;
                    return;
                }

                if (Breakpoints.Contains(i))
                {
                    Paused = true;
                    State = s;
                    Breakpoints.Remove(i);

                    return;
                }

                try
                {
                    s = await s.ContinueWithAsync(Source.Split("\n")[i]);
                }
                catch (Exception ex)
                {
                    UnhandledException(ex);
                    Stop();

                    return;
                }
            }
        }
        else
        {
            for (int i = Line; i < Source.Length; i++)
            {
                Line = i;
                if (!Running || Paused)
                {
                    State = s;
                    return;
                }

                if (Breakpoints.Contains(i))
                {
                    Paused = true;
                    State = s;
                    Breakpoints.Remove(i);

                    return;
                }

                try
                {
                    if (s is null)
                    {
                        s = await CSharpScript.RunAsync<dynamic>(Source.Split("\n")[i]);
                    }
                    else
                    {
                        s = await s.ContinueWithAsync(Source.Split("\n")[i]);
                    }
                }
                catch (Exception ex)
                {
                    UnhandledException(ex);
                    Stop();

                    return;
                }
            }
        }

        void Stop()
        {
            Paused = true;
            State = s;
        }

        void UnhandledException(Exception ex)
        {
            ExceptionCaught = true;
            CaughtException = ex;
        }
    }

    public IEnumerable<Variable> ExamineVariables()
    {
        Debug.Assert(State is not null, "StateIsNull".Resource());

        if (Paused)
        {
            foreach (var variable in State!.Variables) // will give an exception if State is null
            {
                yield return new(variable.Name, variable.Type, variable.IsReadOnly, variable.Value);
            }
        }
    }

    public ScriptState<dynamic> GetEnvironment()
    {
        Debug.Assert(State is not null, "StateIsNull".Resource());

        return State!;
    }

    public void Pause()
    {
        Paused = true;
        Running = false;
    }

    public void Stop()
    {
        Running = false;
    }
}
