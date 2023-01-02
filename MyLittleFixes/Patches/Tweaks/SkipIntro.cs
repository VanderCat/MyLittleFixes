using HarmonyLib;
using UnityEngine;

namespace MyLittleFixes.Patches.Tweaks;

[HarmonyPatch(typeof(IntroScene))]
public class SkipIntro
{
    [HarmonyPatch("Update")]
    [HarmonyPrefix]
    static bool Update(IntroScene __instance, ref int ___phase, ref Animator ___animator)
    {
        if (___phase < 6) {
            ___animator.SetTrigger("Next");
            ___phase = 6;
        }

        return false;
    }
}