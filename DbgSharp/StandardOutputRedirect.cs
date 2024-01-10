namespace DbgSharp;

internal class StandardOutputRedirect : IDisposable
{
    private readonly StringWriter? _sw;
    private bool _disposed = false;

    public StandardOutputRedirect()
    {
        _sw = new();
    }

    public string Redirect(Action action)
    {
        TextWriter tw = Console.Out;
        Console.SetOut(_sw!);

        action();

        Console.SetOut(tw);
        tw.Dispose();

        return _sw!.ToString();
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _disposed = true;
            _sw!.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
