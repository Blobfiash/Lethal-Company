using SpectralWave.TogglesLoadManager;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Misc
{
    internal class NeverLoseScrap : TogglesLoad
    {
        public override void Update()
        {
            if (BNeverLoseScrap && StartOfRound.Instance.allPlayersDead == true && StartOfRound.Instance != null) StartOfRound.Instance.allPlayersDead = false;

        }
    }
}
