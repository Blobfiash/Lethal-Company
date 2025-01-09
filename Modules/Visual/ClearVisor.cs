using SpectralWave.TogglesLoadManager;
using UnityEngine;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Visual
{
    internal class ClearVisor : TogglesLoad
    {
        public override void Update()
        {
            GameObject.Find("Systems/Rendering/PlayerHUDHelmetModel/")?.SetActive(!BClearVisor);
        }
    }
}
