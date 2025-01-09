using static SpectralWave.ToggleManager.ToggleManager;
using SpectralWave.TogglesLoadManager;

namespace SpectralWave.Modules.Player
{
    internal class Reach : TogglesLoad
    {
        public override void Update()
        {
            var player = GameNetworkManager.Instance?.localPlayerController;
            if (player != null)
            {
                player.grabDistance = BReach ? 13f : 4.6f;
            }
        }
    }
}
