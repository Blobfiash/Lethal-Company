using SpectralWave.TogglesLoadManager;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Misc
{
    internal class Exp : TogglesLoad
    {
        public static void ExpMeth(int value) => HUDManager.Instance.localPlayerXP += value;
        public static void RemoveExp(int value) => HUDManager.Instance.localPlayerXP -= value;
    }
}
