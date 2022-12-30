using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Melbot;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyLittleFixes.Patches.BugFix;

[HarmonyPatch(typeof(PauseScreen))]
class PauseScreenPatch
{
    [HarmonyPatch("Start")]
    [HarmonyPrefix]
    static bool Start(PauseScreen __instance)
    {
        var canvases = Traverse.Create(__instance).Field("canvases");
        var myCanvases = Traverse.Create(__instance).Field("myCanvases");
        var cameraSet = Traverse.Create(__instance).Field("cameraSet");
        var allSound = Traverse.Create(__instance).Field("allSound");

        __instance.Focus();

        myCanvases.SetValue(new List<Canvas>(__instance.transform.GetComponentsInChildren<Canvas>(true)));
        
        Canvas component = NonPersistentSingleton<BaseSystem>.Get().sceneLoadFader.logoTransitionAnimator.GetComponent<Canvas>();
        if (component)
        {
            myCanvases.Method("Add", component);
        }
        
        var _cameraSet = Object.FindObjectOfType<CameraSet>();
        cameraSet.SetValue(_cameraSet);
        if (_cameraSet)
        {
           cameraSet.Field("UIOrthographicCamera").Field("cullingMask").SetValue(__instance.uiCamLayerMask);
        }
        
        var activeScene = SceneManager.GetActiveScene();
        var _canvases = Resources.FindObjectsOfTypeAll<Canvas>()
            .Where(c => activeScene == c.gameObject.scene)
            .ToArray();
        foreach (var canvas in _canvases)
        {
            if (!myCanvases.GetValue<List<Canvas>>().Contains(canvas) && canvas != null)
            {
                canvas.enabled = true;
            }
        }
        canvases.SetValue(_canvases);

        var _allSound = Object.FindObjectsOfType<AudioSource>();
        for (var j = 0; j < _allSound.Length; j++)
        {
            if (_allSound[j].loop)
            {
                __instance.loopSounds.Add(_allSound[j]);
            }
        }
        allSound.SetValue(_allSound);
        
        return false;
    }
}