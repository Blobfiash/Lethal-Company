using SpectralWave.Utill;
using UnityEngine;

namespace SpectralWave.UI
{
    public class WaterMark : MonoBehaviour
    {
        private GUIStyle Style;
        private float time;

        void Start() => Style = new GUIStyle { fontSize = 16, normal = { textColor = Color.white }, alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Bold };

        void OnGUI()
        {
            string label = $"SpectralWave | Time: {System.DateTime.Now:hh:mm:ss tt} | FPS: {Mathf.Floor(1.0f / (time += (Time.deltaTime - time) * 0.1f))}";
            float width = Style.CalcSize(new GUIContent(label)).x;
            Rect rect = new Rect((Screen.width - width) / 2, 10, width + 30, 40);
            DrawTexture.DrawTextureRounded(rect, SpectralUI.guibackground, ScaleMode.StretchToFill, true, 1, Color.white, new Vector4(0, 0, 0, 0), new Vector4(8, 8, 8, 8));
            GUI.Label(new Rect(rect.x + 2, rect.y + 2, rect.width, rect.height), label, new GUIStyle(Style) { normal = { textColor = Color.black } });
            string Label = label.Substring(0, label.LastIndexOf("FPS: ") + 5) + $"<color=#{ColorUtility.ToHtmlStringRGBA(Mathf.Floor(1.0f / (time += (Time.deltaTime - time) * 0.1f)) >= 54 ? Color.green : (Mathf.Floor(1.0f / (time += (Time.deltaTime - time) * 0.1f)) >= 20 ? Color.yellow : Color.red))}>{Mathf.Floor(1.0f / (time += (Time.deltaTime - time) * 0.1f))}</color>";
            GUI.Label(rect, Label, Style);
        }
    }
}
