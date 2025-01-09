using SpectralWave.TogglesLoadManager;
using SpectralWave.UI;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Player
{
    internal class NeverInsane : TogglesLoad
    {
        public override void Update()
        {
            if (BNeverInsane)
            {
                SpectralUI.PlayerB.playersManager.gameStats.allPlayerStats[SpectralUI.PlayerB.playerClientId].turnAmount = 0;
                SpectralUI.PlayerB.playersManager.fearLevel = 0.0f;
                SpectralUI.PlayerB.playersManager.fearLevelIncreasing = false;
                SpectralUI.PlayerB.insanityLevel = 0.0f;
                SpectralUI.PlayerB.insanitySpeedMultiplier = 0.0f;
            }
        }
    }
}
