using SpectralWave.TogglesLoadManager;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Misc
{
    internal class Moons : TogglesLoad
    {
        public static void Moon(int i_Moon) 
        {
            if (!StartOfRound.Instance) return;

            StartOfRound.Instance.ChangeLevelServerRpc(i_Moon, Money.Terminal.groupCredits); 
        }
    }
}
