
using SpectralWave.TogglesLoadManager;
using static SpectralWave.ToggleManager.ToggleManager;
namespace SpectralWave.Modules.Player
{
    internal class NoWeight : TogglesLoad
    {
        public override void Update()
        {
            var Player = GameNetworkManager.Instance?.localPlayerController;
            if (BNoWeight && Player != null) Player.carryWeight = 1f;
        }
    }
}
