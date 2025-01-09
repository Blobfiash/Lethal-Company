using SpectralWave.TogglesLoadManager;
using static SpectralWave.ToggleManager.ToggleManager;
using UnityEngine.InputSystem;

namespace SpectralWave.Modules.Visual
{
    internal class Fov : TogglesLoad
    {
        public override void Update()
        {
            var player = GameNetworkManager.Instance?.localPlayerController;
            if (player == null) return;
            player.gameplayCamera.fieldOfView = player.inTerminalMenu ? 66f : (BFov ? FFovValue : player.gameplayCamera.fieldOfView);
        }
    }
}
