using SpectralWave.TogglesLoadManager;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Player
{
    internal class InfAmmo : TogglesLoad
    {
        public static ShotgunItem Shotgun => FindObjectOfType<ShotgunItem>();

        public override void Update()
        {
            if (Shotgun != null && BInfAmmo)
            {
                Shotgun.shellsLoaded = 2;
            }
        }
    }
}
