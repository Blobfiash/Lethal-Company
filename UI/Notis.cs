using UnityEngine;

namespace SpectralWave.UI
{
    internal class Notis : MonoBehaviour
    {
        private bool show;
        private string title = "Reminder", message = "Press Insert to toggle the UI";
        private float displayTime = 5f, timer = 0f;
        private Rect rect = new Rect(Screen.width - 300, 20, 280, 100);
        private Texture2D background;

        void Start() => ShowNotif(title, message, displayTime);

        public void ShowNotif(string t, string m, float d) { title = t; message = m; displayTime = d; show = true; timer = 0f; }

        void Update() => show = show && (timer += Time.deltaTime) <= displayTime;

        void OnGUI()
        {
            if (!show) return;

            background = background ?? new Texture2D(1, 1);
            background.SetPixel(0, 0, new Color(0.1f, 0.4f, 0.7f, 0.8f)); 
            background.Apply();

            GUI.DrawTexture(rect, background);
            var Title = new GUIStyle(GUI.skin.label) { fontSize = 18, fontStyle = FontStyle.Bold, alignment = TextAnchor.UpperLeft, normal = { textColor = Color.white } };
            var Message = new GUIStyle(GUI.skin.label) { fontSize = 14, wordWrap = true, normal = { textColor = Color.white } };

            GUI.Label(new Rect(rect.x + 10, rect.y + 5, rect.width - 20, 30), title, Title);
            GUI.Label(new Rect(rect.x + 10, rect.y + 35, rect.width - 20, rect.height - 40), message, Message);
        }
    }
}
