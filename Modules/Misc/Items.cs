using ExitGames.Client.Photon.StructWrapping;
using SpectralWave.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpectralWave.Modules.Misc
{
    public class Items : TogglesLoadManager.TogglesLoad
    {
        public static List<GrabbableObject> items = new List<GrabbableObject>();
        public static Terminal Term = FindObjectOfType<Terminal>();

        public enum Unlockable
        {
            OrangeSuit, GreenSuit, HazardSuit, PajamaSuit, CozyLights, Teleporter, Television, Toilet = 9,
            Shower, RecordPlayer = 12, Table, RomanticTable, SignalTranslator = 17, LoudHorn, InverseYeleporter,
            JackOLantern, WelcomeMat, Goldfish, PlushiePajamaMan, PurpleSuit, BeeSuit, BunnySuit, DiscoBall
        }

        public override void Update() => items = FindObjectsOfType<GrabbableObject>().ToList();

        public static void TpItems()
        {
            items.Where(i => !i.isHeld && !i.isPocketed && !i.isInShipRoom).ToList().ForEach(i => { Vector3 point = new Ray(SpectralUI.PlayerB.gameplayCamera.transform.position, SpectralUI.PlayerB.gameplayCamera.transform.forward).GetPoint(1f); i.gameObject.transform.position = i.startFallingPosition = i.targetFloorPosition = point;
            });
        }
        public static void PutAllOnDesk()
        {
            var desk = FindObjectOfType<DepositItemsDesk>();
            if (desk == null) return;
            SpectralUI.PlayerB.DropAllHeldItems(true, false);
            items.Where(i => i.itemProperties.isScrap && !i.isHeld && !i.isPocketed).ToList().ForEach(i => { SpectralUI.PlayerB.currentlyHeldObjectServer = i; desk.PlaceItemOnCounter(SpectralUI.PlayerB); });
        }


        public static void HandleItem(Unlockable unlockable, bool unlock = false)
        {
            var item = StartOfRound.Instance.unlockablesList.unlockables[(int)unlockable];
            if (unlock) item.alreadyUnlocked = item.hasBeenUnlockedByPlayer = true;
            StartOfRound.Instance.BuyShipUnlockableServerRpc((int)unlockable, Term.groupCredits);
            StartOfRound.Instance.SyncShipUnlockablesServerRpc();
        }
    }
}
