using SpectralWave.TogglesLoadManager;
using SpectralWave.UI;
using Unity.Netcode;
using UnityEngine;
using System.Linq;

namespace SpectralWave.Modules.Misc
{
    internal class HostOptions : TogglesLoad
    {
        public static void SpawnTurret()
        {
            if (SpectralUI.PlayerB == null || RoundManager.Instance.AnomalyRandom == null) return;

            var spawnable = StartOfRound.Instance?.levels.SelectMany(level => level.spawnableMapObjects).FirstOrDefault(obj => obj.prefabToSpawn.name == "TurretContainer");

            if (spawnable == null) return;

            var spawnedObj = Instantiate(spawnable.prefabToSpawn, SpectralUI.PlayerB.transform.position + SpectralUI.PlayerB.transform.forward * 2f, Quaternion.identity, RoundManager.Instance.mapPropsContainer.transform); 
            spawnedObj.transform.eulerAngles = spawnable.spawnFacingAwayFromWall ? new Vector3(0f, RoundManager.Instance.YRotationThatFacesTheFarthestFromPosition(SpectralUI.PlayerB.transform.position + SpectralUI.PlayerB.transform.forward * 2f + Vector3.up * 0.2f, 25f, 6), 0f)
            : new Vector3(spawnedObj.transform.eulerAngles.x, RoundManager.Instance.AnomalyRandom.Next(0, 360), spawnedObj.transform.eulerAngles.z);

            spawnedObj.GetComponent<NetworkObject>().Spawn(true);
        }
        public static void EjectAll()
        {
            if (StartOfRound.Instance)
            {
                StartOfRound.Instance.ManuallyEjectPlayersServerRpc();
            }
        }
        public static void SpawnMoreScrap()
        {
            if (RoundManager.Instance?.currentLevel.spawnEnemiesAndScrap ?? false)
                RoundManager.Instance.SpawnScrapInLevel();
        }
    }
}
