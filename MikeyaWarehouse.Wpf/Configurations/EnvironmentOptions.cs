using System.IO;
using System.Reflection;
using DotNetEnv;

namespace MikeyaWarehouse.Wpf.Configurations;

public static class EnvLoader
{
    private static bool _loaded = false;

    public static void Load(string fileName = ".env")
    {
        if (_loaded) return;

        try
        {
            string path = Path.Combine(
                Directory.GetCurrentDirectory(), fileName);
            
            Env.Load(path);

            _loaded = true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Warning: Couldn't load .env file: {ex.Message}");
        }
    }

    public static string Get(string key, string defaultValue = "")
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), ".env");
        if (!_loaded) Load(path);

        return Environment.GetEnvironmentVariable(key) ?? defaultValue;
    }
}