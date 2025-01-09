using HarmonyLib;
using UnityEngine;

namespace SpectralWave.Utill
{
    public class HarmonyPatches : MonoBehaviour
    {
        private void Awake()
        {
            var harmony = new Harmony("SpectralWaveCheats");
            harmony.PatchAll();
        }
    }
}
