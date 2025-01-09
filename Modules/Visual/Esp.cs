using GameNetcodeStuff;
using SpectralWave.TogglesLoadManager;
using UnityEngine;
using System.Linq;
using static SpectralWave.ToggleManager.ToggleManager;
using SpectralWave.Utill;

namespace SpectralWave.Modules.Visual
{
    public class Esp : MonoBehaviour
    {
        void OnGUI()
        {
            var Player = GameNetworkManager.Instance?.localPlayerController;
            if (Player == null || Player.gameplayCamera == null) return;

            if (BScrapEsp)
                Label<GrabbableObject>(Player.gameplayCamera, Player.transform.position, Color.red, (g) => g.itemProperties.itemName, g => g.transform.position);
            if (BPlayersEsp)
                Label<PlayerControllerB>(Player.gameplayCamera, Player.transform.position, Color.white, (p) => p.playerUsername, p => p.transform.position);
            if (BEnemyEsp)
                Label<EnemyAI>(Player.gameplayCamera, Player.transform.position, Color.white, (e) => e.enemyType.enemyName, e => e.transform.position);
        }

        private void Label<T>(Camera cam, Vector3 Pos, Color color, System.Func<T, string> Text, System.Func<T, Vector3> GetPos) where T : MonoBehaviour
        {
            var objects = FindObjectsOfType<T>().ToList();
            foreach (var obj in objects)
            {
                var ScreenPos = cam.WorldToViewportPoint(GetPos(obj));
                if (ScreenPos.z > 0 && Vector3.Distance(Pos, GetPos(obj)) <= 20f)
                {
                    var label = Text(obj);
                    if (obj is GrabbableObject)
                        Render.Circle(new Vector2(ScreenPos.x * Screen.width, (1 - ScreenPos.y) * Screen.height), 10f, 2f, color);
                    else
                        Render.DrawString(new Vector2(ScreenPos.x * Screen.width, (1 - ScreenPos.y) * Screen.height), label, color);
                }
            }
        }
    }
}
