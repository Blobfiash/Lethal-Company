using SpectralWave.TogglesLoadManager;
using SpectralWave.UI;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Visual
{
    internal class NoFlashbang : TogglesLoad
    {
        public override void Update()
        {
            if (BNoFlashBang)
            {
                if (SpectralUI.PlayerB != null)
                {
                    if (HUDManager.Instance != null)
                    {
                        HUDManager.Instance.flashbangScreenFilter.weight = 0f;
                    }

                    if (SoundManager.Instance != null)
                    {
                        SoundManager.Instance.earsRingingTimer = 0f;
                    }
                }
            }
        }
    }
}
