using HarmonyLib;
using UnityEngine;

namespace MyLittleFixes.Patches.Gameplay;

[HarmonyPatch(typeof(AINavigator))]
public class DisableShimmerwing
{
    [HarmonyPatch("Awake")]
    [HarmonyPostfix]
    static void Awake(AINavigator __instance)
    {
        __instance.gameObject.SetActive(false);
    }
}