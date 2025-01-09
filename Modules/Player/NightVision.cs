using SpectralWave.TogglesLoadManager;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Player
{
    internal class NightVision : TogglesLoad
    {
        public override void Update()
        {
            var Player = GameNetworkManager.Instance?.localPlayerController;
            if (BNightVision && Player != null)
            {
                Player.nightVision.enabled = BNightVision || Player.isInsideFactory;
                Player.nightVision.intensity = BNightVision ? 3007f : 360f;
                Player.nightVision.range = BNightVision ? 20000f : 12f;
            }
        }
    }
}
