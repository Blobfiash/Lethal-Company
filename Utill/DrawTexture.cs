using System.Linq;
using UnityEngine;

namespace SpectralWave.Utill
{
    public class DrawTexture
    {
        /* https://docs.unity3d.com/6000.0/Documentation/ScriptReference/GUI.DrawTexture.html ↓ ↓ ↓ */
        public static void DrawTextureRounded(Rect position, Texture texture, ScaleMode scaleMode, bool alphaBlend, float imageAspect, Color color, Vector4 borderWidths, Vector4 borderRadiuses)
        => GUI.DrawTexture(position, texture, scaleMode, alphaBlend, imageAspect, color, borderWidths, borderRadiuses);

       /* public static Rect GetRect(float width, float height, params GUILayoutOption[] options) => GUILayoutUtility.GetRect(width, height, GUIStyle.none, options); */

        public static Texture2D CreateTex(int width, int height, Color col) => Enumerable.Range(0, 1).Select(i => { Texture2D tex = new Texture2D(width, height); tex.SetPixels(Enumerable.Repeat(col, width * height).ToArray()); tex.Apply(); return tex; }).FirstOrDefault();


    }
}
