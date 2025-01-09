using SpectralWave.TogglesLoadManager;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpectralWave.Modules.Misc
{
    internal class EnemysMain : TogglesLoad
    {
        public static List<EnemyAI> enemies = new List<EnemyAI>();

        public override void Update() => enemies = FindObjectsOfType<EnemyAI>().ToList();

        public static void KillAllEnemys() => enemies.ForEach(Enemy => Enemy?.KillEnemyServerRpc(false));
    }
}
