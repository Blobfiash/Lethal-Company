
using SpectralWave.TogglesLoadManager;
using static SpectralWave.ToggleManager.ToggleManager;
namespace SpectralWave.Modules.Player
{
    internal class HandItems : TogglesLoad
    {
        public override void Update()
        {
            var Player = GameNetworkManager.Instance?.localPlayerController;
            if (BOneHandItems && Player != null) Player.twoHanded = false; // Will auto reset when off
        }
    }
}
