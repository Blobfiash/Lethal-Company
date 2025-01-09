using SpectralWave.Utill;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static SpectralWave.UI.SpectralUI;
using static UnityEngine.Rendering.DebugUI;

namespace SpectralWave.UI.Managment
{
    public class GUIButtons : MonoBehaviour 
    {
        public static void CreateSect(string title, System.Action Act)
        {
            Rect boxRect = new Rect(140, 50, 427, 348);
            GUI.Label(new Rect(boxRect.x + 10, boxRect.y, 170, 100), $"<size=28><b>{title}</b></size>");
            GUILayout.BeginArea(new Rect(boxRect.x + 10, boxRect.y + 35, boxRect.width - 20, boxRect.height - 30));
            GUILayout.Space(10); Act?.Invoke(); GUILayout.EndArea();
        }

        public static HashSet<string> Hash = new HashSet<string>();
        public static void CreateDropDown(string title, int Amount, System.Action Act)
        {
            bool pars = Hash.Contains(title);
            Rect rect = GUILayoutUtility.GetRect(320, 40);
            GUI.DrawTexture(new Rect(rect.x + 2.6f, rect.y, 390, 39), DropDownTexture);

            if (GUI.Button(new Rect(rect.x + 30, rect.y + 8f, 180, 29), $"<color=#fffff><size=14><b>{title}</b> {(pars ? "Open" : "Closed")}</size></color>", GUIStyle.none))
                if (pars) Hash.Remove(title); else Hash.Add(title);

            if (pars)
            {
                GUI.DrawTexture(new Rect(rect.x + 2, rect.y + 40, 310, 43 * Amount), DropDownTexture);
                GUILayout.Space(5f);
                GUIStyle s = new GUIStyle(GUI.skin.box) { normal = { background = DropDownTexture }, active = { background = DropDownTexture }, hover = { background = DropDownTexture } };
                Act?.Invoke();
            }

            GUILayout.Space(5);
        }

        public static void CreateLabel(string text)
        {
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label($"<size=18><b>{text}</b></size>");
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        } 
        public static bool CreateToggle(bool value, string text)
        {
            GUILayout.BeginHorizontal();
            Rect rect = GUILayoutUtility.GetRect(28, 27, GUILayout.ExpandWidth(false));
            DrawTexture.DrawTextureRounded(rect, value ? activebuttonTexture : normalToggleTexture, ScaleMode.StretchToFill, true, 1f, Color.white, Vector4.zero, new Vector4(4f, 4f, 4f, 4f));
            if (GUI.Button(new Rect(rect.x + 5, rect.y + 6f, 25f, 29f), "", GUIStyle.none)) value = !value;

            GUI.Label(new Rect(rect.x + 45, rect.y + 2f, 1000, 24), $"<b>{text}</b>", new GUIStyle(GUI.skin.label) { fontSize = 14, richText = true });
            GUILayout.EndHorizontal();
            GUILayout.Space(3f);
            return value;
        }
        public static void CreateButton(string text, System.Action action)
        {
            Rect rect = GUILayoutUtility.GetRect(320, 40);
            GUILayout.BeginHorizontal();
            Rect buttonRect = new Rect(rect.x + 210, rect.y + 6f, 75, 25f);
            DrawTexture.DrawTextureRounded(buttonRect, normalbuttonTexture, ScaleMode.StretchToFill, true, 1f, Color.white, Vector4.zero, new Vector4(6, 6, 6, 6));
            if (GUI.Button(buttonRect, "<b>Execute</b>", new GUIStyle { alignment = TextAnchor.MiddleCenter, normal = { textColor = Color.white } })) action?.Invoke();
            GUI.Label(new Rect(rect.x + 35, rect.y + 7f, 1000, 24), $"<b>{text}</b>");
            GUILayout.EndHorizontal();
            GUILayout.Space(3f);
        }

        public static float SlideWidth = 190;

        public static void CreateSlider(ref float value, float minValue, float maxValue, string label)
        {
            float filledWidth = SlideWidth * (value - minValue) / (maxValue - minValue);
            Rect rect = GUILayoutUtility.GetRect(320, 40);

            DrawTexture.DrawTextureRounded(new Rect(rect.x + 5, rect.y + 7f, SlideWidth, 18), SliderTexture, ScaleMode.StretchToFill, true, 1, Color.white, new Vector4(0, 0, 0, 0), new Vector4(9, 9, 9, 9));
            DrawTexture.DrawTextureRounded(new Rect(rect.x + 5 + Mathf.Clamp(filledWidth - 10, 0, SlideWidth - 20), rect.y + 7f, 20, 20), SliderBcTexture, ScaleMode.StretchToFill, true, 1, Color.white, new Vector4(0, 0, 0, 0), new Vector4(10, 10, 10, 10));

            value = GUI.HorizontalSlider(new Rect(rect.x + 5, rect.y + 7f, SlideWidth, 16.5f), value, minValue, maxValue, GUIStyle.none, GUIStyle.none);
            GUI.Label(new Rect(rect.x + 210, rect.y + 7f, 100, 24), $"<b>{label}: {Mathf.Round(value)}</b>");
            GUILayout.Space(3f);
        }
    }
}
