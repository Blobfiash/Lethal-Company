using SpectralWave.TogglesLoadManager;
using SpectralWave.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Player
{
    internal class NoClip : TogglesLoad
    {
        public override void Update()
        {
            if (BNoClip && SpectralUI.PlayerB)
            {
                SpectralUI.PlayerB.GetComponent<CharacterController>().enabled = false; 

                var LocalP = GameNetworkManager.Instance?.localPlayerController; 

                if (!Cursor.visible)
                {
                    Vector3 Vect = Vector3.zero;
                    if (SpectralUI.PlayerB.gameplayCamera != null)
                    {
                        Vector3 forward = SpectralUI.PlayerB.gameplayCamera.transform.forward;
                        Vector3 right = SpectralUI.PlayerB.gameplayCamera.transform.right;
                        forward.y = right.y = 0f;
                        forward.Normalize();
                        right.Normalize();

                        if (Keyboard.current.wKey.isPressed) Vect += SpectralUI.PlayerB.gameplayCamera.transform.forward;
                        if (Keyboard.current.sKey.isPressed) Vect -= forward;
                        if (Keyboard.current.aKey.isPressed) Vect -= right;
                        if (Keyboard.current.dKey.isPressed) Vect += right;
                        if (Keyboard.current.spaceKey.isPressed) Vect += Vector3.up;
                        if (Keyboard.current.ctrlKey.isPressed) Vect -= Vector3.up;
                    }

                    if (Vect != Vector3.zero && LocalP != null)
                    {
                        LocalP.transform.position = LocalP.transform.position + Vect * Time.deltaTime * SpectralUI.PlayerB.movementSpeed;
                    }
                }

                if (LocalP != null)
                {
                    LocalP.transform.position = SpectralUI.PlayerB.transform.position;
                    LocalP.transform.rotation = SpectralUI.PlayerB.transform.rotation;
                }
            }
            else
            {
                var ChCon = SpectralUI.PlayerB?.GetComponent<CharacterController>();
                if (ChCon != null)
                {
                    ChCon.enabled = true; 
                }
            }
        }
    }
}
