using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SpectralWave.Utill
{
    public class Render : MonoBehaviour
    {
        public static GUIStyle StringStyle { get; set; } = new GUIStyle(GUI.skin.label);
        public static Color Color
        {
            get
            {
                return GUI.color;
            }
            set
            {
                GUI.color = value;
            }
        }
        public static void DrawBox(Vector2 position, Vector2 size, Color color, bool centered = true)
        {
            Render.Color = color;
            Render.DrawBox(position, size, centered);
        }

        public static void DrawBox(Vector2 position, Vector2 size, bool centered = true)
        {
            Vector2 vector = centered ? (position - size / 2f) : position;
            GUI.DrawTexture(new Rect(position, size), Texture2D.whiteTexture, 0);
        }


        public static void DrawString(Vector2 position, string label, Color color, bool centered = true)
        {
            Render.Color = color;
            Render.DrawString(position, label, centered);
        }
        public static void Circle(Vector2 center, float radius, float thickness, Color color)
        {
            Render.Color = color;
            Vector2 from = center + new Vector2(radius, 0f);
            for (int i = 1; i <= 360; i++)
            {
                float f = (float)i * 0.017453292f;
                Vector2 vector = center + new Vector2(radius * Mathf.Cos(f), radius * Mathf.Sin(f));
                Render.Line(from, vector, thickness);
                from = vector;
            }
        }
        public static void Line(Vector2 from, Vector2 to, float thickness)
        {
            Vector2 normalized = (to - from).normalized;
            float num = Mathf.Atan2(normalized.y, normalized.x) * 57.29578f;
            GUIUtility.RotateAroundPivot(num, from);
            Render.Box(from, Vector2.right * (from - to).magnitude, thickness, false);
            GUIUtility.RotateAroundPivot(-num, from);
        }
        public static void Box(Vector2 position, Vector2 size, float thickness, bool centered = true)
        {
            if (centered)
            {
                position -= size / 2f; 
            }
            GUI.DrawTexture(new Rect(position.x, position.y, size.x, thickness), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(position.x, position.y, thickness, size.y), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(position.x + size.x, position.y, thickness, size.y), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(position.x, position.y + size.y, size.x + thickness, thickness), Texture2D.whiteTexture);
        }


        public static void DrawString(Vector2 position, string label, bool centered = true)
        {
            GUIContent guicontent = new GUIContent(label);
            Vector2 vector = Render.StringStyle.CalcSize(guicontent);
            Vector2 position2 = centered ? (position - vector / 2f) : position;
            GUI.Label(new Rect(position2, vector), guicontent);
        }

        public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color, float width)
        {
            Matrix4x4 matrix = GUI.matrix;
            bool flag = !Render.lineTex;
            if (flag)
            {
                Render.lineTex = new Texture2D(1, 1);
            }
            Color color2 = GUI.color;
            GUI.color = color;
            float num = Vector3.Angle(pointB - pointA, Vector2.right);
            bool flag2 = pointA.y > pointB.y;
            if (flag2)
            {
                num = -num;
            }
            GUIUtility.ScaleAroundPivot(new Vector2((pointB - pointA).magnitude, width), new Vector2(pointA.x, pointA.y + 0.5f));
            GUIUtility.RotateAroundPivot(num, pointA);
            GUI.DrawTexture(new Rect(pointA.x, pointA.y, 1f, 1f), Render.lineTex);
            GUI.matrix = matrix;
            GUI.color = color2;
        }

        public static void DrawBox(float x, float y, float w, float h, Color color, float thickness)
        {
            Render.DrawLine(new Vector2(x, y), new Vector2(x + w, y), color, thickness);
            Render.DrawLine(new Vector2(x, y), new Vector2(x, y + h), color, thickness);
            Render.DrawLine(new Vector2(x + w, y), new Vector2(x + w, y + h), color, thickness);
            Render.DrawLine(new Vector2(x, y + h), new Vector2(x + w, y + h), color, thickness);
        }

        public static void DrawBoxOutline(Vector2 Point, float width, float height, Color color, float thickness)
        {
            Render.DrawLine(Point, new Vector2(Point.x + width, Point.y), color, thickness);
            Render.DrawLine(Point, new Vector2(Point.x, Point.y + height), color, thickness);
            Render.DrawLine(new Vector2(Point.x + width, Point.y + height), new Vector2(Point.x + width, Point.y), color, thickness);
            Render.DrawLine(new Vector2(Point.x + width, Point.y + height), new Vector2(Point.x, Point.y + height), color, thickness);
        }
        public static void DrawColorString(Vector2 position, string label, Color color, float size, bool centered = true)
        {
            GUIContent content = new GUIContent(label);
            GUIStyle guistyle = new GUIStyle();
            guistyle.fontSize = Mathf.RoundToInt(size);
            guistyle.normal.textColor = color;
            Vector2 vector = guistyle.CalcSize(content);
            GUI.Label(new Rect(centered ? (position - vector / 2f) : position, vector), content, guistyle);
        } public static Texture2D lineTex;
    }
}
