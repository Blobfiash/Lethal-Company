using SpectralWave.TogglesLoadManager;
using SpectralWave.UI;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Visual
{
    internal class ShowClock : TogglesLoad
    {
        public override void Update()
        {
            if (SpectralUI.PlayerB != null && HUDManager.Instance != null)
            {
                if (SpectralUI.PlayerB.isInsideFactory && BShowClock)
                {
                    HUDManager.Instance.SetClockVisible(true);
                }
            }
        }
    }
}
