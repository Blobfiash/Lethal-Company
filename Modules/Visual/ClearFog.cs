using SpectralWave.TogglesLoadManager;
using UnityEngine;
using UnityEngine.Rendering;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Visual
{
    internal class ClearFog : TogglesLoad
    {
        public override void Update()
        {
            var render = GameObject.Find("Systems")?.transform.Find("Rendering");
            if (render == null) return;

            render.Find("VolumeMain")?.gameObject.SetActive(!BNoFog);
            render.Find("VolumeMain (1)")?.gameObject.SetActive(!BNoFog);
        }
    }
}
