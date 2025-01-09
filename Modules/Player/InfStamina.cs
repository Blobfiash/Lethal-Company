using SpectralWave.TogglesLoadManager;
using SpectralWave.UI;
using static SpectralWave.ToggleManager.ToggleManager;
namespace SpectralWave.Modules.Player
{
    internal class InfStamina : TogglesLoad
    {
        public override void Update()
        {
            if (BInfStamina && SpectralUI.PlayerB != null)
                SpectralUI.PlayerB.sprintMeter = 1f;
        }
    }
}
