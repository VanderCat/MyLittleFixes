using BepInEx;
using HarmonyLib;
using MyLittleFixes.Patches.BugFix;
using MyLittleFixes.Patches.Gameplay;
using MyLittleFixes.Patches.Tweaks;
using UnityEngine;

namespace MyLittleFixes
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Core : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            MyLittleFixes.Config.LoadConfig();
            var harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            Logger.LogInfo("Config successfully loaded!");
            if (MyLittleFixes.Config.Bugfix.PauseScreenCanvasFix.Value)
            {
                harmony.PatchAll(typeof(PauseScreenPatch));
            }
            if (MyLittleFixes.Config.Bugfix.HideMouse.Value)
            {
                Cursor.visible = false;
            }
            
            if (MyLittleFixes.Config.Gameplay.DisableShimmerwing.Value)
            {
                harmony.PatchAll(typeof(DisableShimmerwing));
            }
            
            if (MyLittleFixes.Config.Tweaks.SkipIntro.Value)
            {
                harmony.PatchAll(typeof(SkipIntro));
            }
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}