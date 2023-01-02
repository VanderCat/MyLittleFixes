using System.IO;
using BepInEx;
using BepInEx.Configuration;

namespace MyLittleFixes;

public static class Config
{
    private const string FileName = "MyLittleFixes.cfg";
    private static readonly string FilePath = Path.Combine(Paths.ConfigPath, FileName);
    
    private static readonly ConfigFile File = new (FilePath, true);

    public static class Gameplay
    {
        public static ConfigEntry<bool> DisableShimmerwing;
    }

    public static class Bugfix
    {
        public static ConfigEntry<bool> PauseScreenCanvasFix;
        public static ConfigEntry<bool> HideMouse;
    }
    public static class Tweaks
    {
        public static ConfigEntry<bool> SkipIntro;
    }
    
    public static void LoadConfig()
    {
        // Gameplay
        Gameplay.DisableShimmerwing = File.Bind<bool>(nameof(Gameplay),
            nameof(Gameplay.DisableShimmerwing),
            false,
            "Disable spawning of Shimmerwing");
        // Bugfix
        Bugfix.PauseScreenCanvasFix = File.Bind<bool>(nameof(Bugfix),
            nameof(Bugfix.PauseScreenCanvasFix),
            true,
            "Fix bug in pause screen. By default it disables ALL canvases in ALL scenes. \nFixes Unity Explorer disappearance after opening the pause screen");
        Bugfix.HideMouse = File.Bind<bool>(nameof(Bugfix),
            nameof(Bugfix.HideMouse),
            true,
            "Hide mouse in-game (it isn't used anyway)");
        // Tweak
        Tweaks.SkipIntro = File.Bind<bool>(nameof(Tweaks),
            nameof(Tweaks.SkipIntro),
            false,
            "Skip Intros at game launch");
    }
}