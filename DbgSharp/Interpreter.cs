using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.Text;

namespace DbgSharp;

/// <summary>
/// Interprets C# scripts
/// </summary>
public class Interpreter
{
    private readonly StringBuilder? _fullCode;
    private ScriptState<dynamic>? _environment;

    /// <summary>
    /// Initializes a new instance of <see cref="Interpreter"/>.
    /// </summary>
    public Interpreter()
    {
        _fullCode = new();
        _environment = null;
    }

    /// <summary>
    /// Interprets C# code.
    /// </summary>
    /// <param name="code">
    /// Input code
    /// </param>
    /// <returns>
    /// Standard Output Stream content from the C# script
    /// </returns>
    public string Interpret(string code)
    {
        _fullCode!.AppendLine(code);
        string content;

        if (_environment is null)
        {
            using var redir = new StandardOutputRedirect();
            content = redir.Redirect(() =>
            {
                _environment = CSharpScript.RunAsync(code).Result;
            });
        }
        else
        {
            using var redir = new StandardOutputRedirect();
            content = redir.Redirect(() =>
            {
                _environment = _environment.ContinueWithAsync(code).Result;
            });
        }

        return content;
    }

    /// <summary>
    /// Interprets C# code asynchronously.
    /// </summary>
    /// <param name="code">
    /// Input code
    /// </param>
    /// <returns>
    /// Standard Output Stream content from the C# script
    /// </returns>
    public string InterpretAsync(string code)
    {
        _fullCode!.AppendLine(code);
        string content;

        if (_environment is null)
        {
            using var redir = new StandardOutputRedirect();
            content = redir.Redirect(async () =>
            {
                _environment = await CSharpScript.RunAsync(code);
            });
        }
        else
        {
            using var redir = new StandardOutputRedirect();
            content = redir.Redirect(async () =>
            {
                _environment = await _environment.ContinueWithAsync(code);
            });
        }

        return content;
    }

    /// <summary>
    /// Code that was built from all <see cref="Interpreter.Interpret(string)"/> or
    /// <see cref="Interpreter.InterpretAsync(string)"/> calls.
    /// </summary>
    public string FullCode
    {
        get
        {
            return _fullCode!.ToString();
        }
    }

    /// <summary>
    /// Script state that was used from all Interpret(String) calls.
    /// </summary>
    public ScriptState<dynamic> Environment
    {
        get
        {
            return _environment!;
        }
    }
}
