using System.Globalization;
using LangJsonSharp;

namespace DbgSharp;

internal static class LocalizationHelper
{
    private static MultipleLanguageManager Manager = new("DbgSharp");

    public static void TryGetString(string name, out string value)
    {
        try
        {
            value = Manager[name]!;
        }
        catch
        {
            value = string.Empty;
        }
    }

    public static void ChangeCulture(string cultureName)
    {
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);
        Manager = new("DbgSharp");
    }

    public static string GetString(string name)
        => Manager[name]!;

    public static string Resource(this string name)
        => GetString(name);
}
