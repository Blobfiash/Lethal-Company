using SpectralWave.TogglesLoadManager;
using System.Linq;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Player
{
    internal class InfBattery : TogglesLoad
    {
        public override void Update()
        {
            var player = GameNetworkManager.Instance?.localPlayerController;
            if (BInfBattery && player != null)
            {
                foreach (var grabbable in player.ItemSlots.Where(g => g?.itemProperties.requiresBattery == true))
                {
                    grabbable.insertedBattery.charge = 1f;
                    grabbable.SyncBatteryServerRpc(100);
                }
            }
        }
    }
}
