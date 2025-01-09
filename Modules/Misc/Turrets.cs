using SpectralWave.TogglesLoadManager;
using System.Collections.Generic;
using System.Linq;
using Zorro.UI;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Misc
{
    internal class Turrets : TogglesLoad
    {
        public static List<Turret> Turret = new List<Turret>();

        public override void Update() => Turret = FindObjectsOfType<Turret>().ToList();

        public static void BerserkTurrets() => Turret.ForEach(t => t.EnterBerserkModeServerRpc(0));
    }
}
