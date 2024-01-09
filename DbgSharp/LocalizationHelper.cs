using System.Resources;
using System.Reflection;
using System.Globalization;

[assembly: NeutralResourcesLanguage("en")]

namespace DbgSharp;

internal static class LocalizationHelper
{
    private static ResourceManager Manager = new("DbgSharp.Resources.Strings",
                                                 Assembly.GetExecutingAssembly());

    public static void TryGetString(string name, out string value)
    {
        try
        {
            value = Manager.GetString(name)!;
        }
        catch
        {
            value = string.Empty;
        }
    }

    public static void ChangeCulture(string cultureName)
    {
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);
        Manager = new("DbgSharp.Resources.Strings", // reinitialize just in case
                      Assembly.GetExecutingAssembly());
    }

    public static string GetString(string name)
        => Manager.GetString(name)!;

    public static string Resource(this string name)
        => GetString(name);
}
