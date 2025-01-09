using SpectralWave.TogglesLoadManager;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Player
{
    internal class HighJump : TogglesLoad
    {
        public override void Update()
        {
            var player = GameNetworkManager.Instance?.localPlayerController;
            if (player != null)
            {
                player.jumpForce = BHighJump ? FHighJump : 13f;
            }
        }
    }
}
