using SpectralWave.TogglesLoadManager;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static SpectralWave.ToggleManager.ToggleManager;
using SpectralWave.UI;

namespace SpectralWave.Modules.Misc
{
    internal class Doors : TogglesLoad
    {
        public static List<TerminalAccessibleObject> BigDoors = new List<TerminalAccessibleObject>();
        public static List<DoorLock> doors = new List<DoorLock>();

        public static void UnlockAll() => doors.Where(d => d.isLocked).ToList().ForEach(d => d.UnlockDoorServerRpc());

        public static void TpEntrance() => SpectralUI.PlayerB.TeleportPlayer(RoundManager.FindMainEntranceScript(true).entrancePoint.position);

        public override void Update()
        {
            if (GameNetworkManager.Instance?.localPlayerController == null) return;
            doors = FindObjectsOfType<DoorLock>().ToList();
            if (!BUnlockDoor) return;
            BigDoors = FindObjectsOfType<TerminalAccessibleObject>().ToList();
            var player = GameNetworkManager.Instance.localPlayerController;
            var CurrCam = player.gameplayCamera ?? (player.isPlayerDead ? StartOfRound.Instance.spectateCamera : Camera.main);

            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                if (Physics.Raycast(CurrCam.transform.position, CurrCam.transform.forward, out var hit, 5f, LayerMask.GetMask("InteractableObject")))
                {
                    hit.transform.GetComponent<DoorLock>()?.UnlockDoorSyncWithServer();
                }
                else
                {
                    foreach (var terminal in BigDoors)
                    {
                        var direction = terminal.transform.position - player.transform.position;
                        if (Vector3.Angle(player.transform.forward, direction) < 60f && direction.magnitude < 5f)
                            terminal.CallFunctionFromTerminal();
                    }
                }
            }
        }
    }
}
