using SpectralWave.Modules.Misc;
using SpectralWave.Utill;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
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
        public static void CreateBox(string title, System.Action Act)
        {
            Rect BoxRect = new Rect(160f, 50f, 222f, 240f);
            DrawTexture.DrawTextureRounded(BoxRect, BoxTexture, ScaleMode.StretchToFill, true, 1f, Color.white, Vector4.zero, new Vector4(4f, 4f, 4f, 4f));

            GUI.Label(new Rect(BoxRect.x + 10f, BoxRect.y + 2, BoxRect.width - 20f, 30f), "<size=16><b>" + title + "</b></size>");

            GUILayout.BeginArea(new Rect(BoxRect.x + 10f, BoxRect.y + 30f, BoxRect.width - 20f, BoxRect.height - 40f));
            if (Act != null) Act();
            GUILayout.EndArea();
        }


        public static void CreateRightBox(string title, System.Action Act)
        {
            Rect RightBoxRect = new Rect(390f, 50f, 250f, 240f);
            DrawTexture.DrawTextureRounded(RightBoxRect, BoxTexture, ScaleMode.StretchToFill, true, 1f, Color.white, Vector4.zero, new Vector4(4f, 4f, 4f, 4f));
            GUI.Label(new Rect(RightBoxRect.x + 10f, RightBoxRect.y + 2, RightBoxRect.width - 20f, 30f), "<size=16><b>" + title + "</b></size>");
            GUILayout.BeginArea(new Rect(RightBoxRect.x + 10f, RightBoxRect.y + 30f, RightBoxRect.width - 20f, RightBoxRect.height - 40f));
            Act();
            GUILayout.EndArea();
        }

        /*  ONLY USIING IF THERE IS NO RIGHT BOX!!!!  */
        public static void CreateLeftBox(string title, System.Action Act)
        {
            Rect LeftBoxRect = new Rect(160f, 50f, 300f, 250f);
            DrawTexture.DrawTextureRounded(LeftBoxRect, BoxTexture, ScaleMode.StretchToFill, true, 1f, Color.white, Vector4.zero, new Vector4(4f, 4f, 4f, 4f));
            GUI.Label(new Rect(LeftBoxRect.x + 10f, LeftBoxRect.y + 2, LeftBoxRect.width - 20f, 20f), "<size=16><b>" + title + "</b></size>");
            GUILayout.BeginArea(new Rect(LeftBoxRect.x + 20f, LeftBoxRect.y + 30f, LeftBoxRect.width - 20f, LeftBoxRect.height - 40f));
            if (Act != null) Act();
            GUILayout.EndArea();
        }

        public static bool CreateToggle(bool value, string text)
        {
            GUILayout.BeginHorizontal();
            Rect rect = DrawTexture.GetRect(28, 27, GUILayout.ExpandWidth(false));
            DrawTexture.DrawTextureRounded(rect, value ? activebuttonTexture : normalToggleTexture, ScaleMode.StretchToFill, true, 1f, Color.white, Vector4.zero, new Vector4(4f, 4f, 4f, 4f));
            if (GUI.Button(new Rect(rect.x + 5, rect.y + 6f, 25f, 29f), "", GUIStyle.none)) value = !value;

            GUI.Label(new Rect(rect.x + 45, rect.y + 2f, 1000, 24), $"<b>{text}</b>", new GUIStyle(GUI.skin.label) { fontSize = 14, richText = true });
            GUILayout.EndHorizontal();
            GUILayout.Space(3f);
            return value;
        }
        public static void CreateButton(string text, System.Action Act)
        {
            Rect rect = DrawTexture.GetRect(320, 40);
            GUILayout.BeginHorizontal();
            Rect buttonRect = new Rect(rect.x + 5, rect.y + 6f, 75, 25f); 
            DrawTexture.DrawTextureRounded(buttonRect, normalbuttonTexture, ScaleMode.StretchToFill, true, 1f, Color.white, Vector4.zero, new Vector4(6, 6, 6, 6));
            if (GUI.Button(buttonRect, "<b>Execute</b>", new GUIStyle { alignment = TextAnchor.MiddleCenter, normal = { textColor = Color.white } })) Act?.Invoke();
            GUI.Label(new Rect(rect.x + 85, rect.y + 7f, 1000, 24), $"<b>{text}</b>"); 
            GUILayout.EndHorizontal();
            GUILayout.Space(3f);
        }


        public static float SlideWidth = 190;
        public static void CreateSlider(ref float value, float minValue, float maxValue, string label)
        {
            float w = 120f, f = w * (value - minValue) / (maxValue - minValue);
            Rect r = DrawTexture.GetRect(320, 40);
            DrawTexture.DrawTextureRounded(new Rect(r.x + 5, r.y + 7f, w, 18), SliderTexture, ScaleMode.StretchToFill, true, 1, Color.white, Vector4.zero, new Vector4(9, 9, 9, 9));
            DrawTexture.DrawTextureRounded(new Rect(r.x + 5 + Mathf.Clamp(f - 10, 0, w - 20), r.y + 7f + 6, 20, 6), SliderBcTexture, ScaleMode.StretchToFill, true, 1, Color.white, Vector4.zero, Vector4.zero);
            value = GUI.HorizontalSlider(new Rect(r.x + 5, r.y + 7f, w, 16.5f), value, minValue, maxValue, GUIStyle.none, GUIStyle.none);
            GUI.Label(new Rect(r.x + 130, r.y + 7f, 100, 24), $"<b>{label}: {Mathf.Round(value)}</b>");
            GUILayout.Space(3f);
        }

    }
}
