using SpectralWave.TogglesLoadManager;
using SpectralWave.UI;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Player
{
    internal class Speed : TogglesLoad
    {
        public static float FSpeedV = 6.6f;
        public override void Update()
        {
            if (SpectralUI.PlayerB != null)
                SpectralUI.PlayerB.movementSpeed = BSpeedBoost ? FSpeedV : 4.6f;
        }
        internal class FasterClimb : TogglesLoad
        {
            public override void Update()
            {
                if (SpectralUI.PlayerB != null)
                    SpectralUI.PlayerB.climbSpeed = BFasterClimb ? 6f : 4f;
            }
        }
    }
}
