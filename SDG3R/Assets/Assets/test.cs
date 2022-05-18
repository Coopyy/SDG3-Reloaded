using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class test : MonoBehaviour
{
    public GUISkin skin;
    private static Texture2D backgroundTexture;
    private static GUIStyle textureStyle;
    public Color c1;
    public Color c2;
    // Use this for initialization
    void Start()
    {
        c1 = Color.red;
        c2 = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        backgroundTexture = Texture2D.whiteTexture;
        textureStyle = new GUIStyle { normal = new GUIStyleState { background = backgroundTexture } };
    }

    // Update is called once per frame
    void OnGUI()
    {
        GUI.skin = skin;

        float max = 500;
        float score = 225;
        float score1 = 225;
        int width = (int)((Screen.width / 10) * (score / max));
        int width1 = (int)((Screen.width / 10) * (score1 / max));

        GUI.Box(new Rect((Screen.width / 2) - 30, 10, 80, 30), "04:23", style: "TimerBG");
        GUI.color = c1;
        GUI.Box(new Rect((Screen.width / 2) + 50, 10, (Screen.width / 10) + 2, 30), "", style: "ScoreBGRight");
        DrawColor(new Rect((Screen.width / 2) + 51, 11, width, 28), c1);
        GUI.Box(new Rect((Screen.width / 2) + 50, 10, (Screen.width / 10) + 2, 30), score.ToString(), style: "ScoreRight");


        DrawColor(new Rect((Screen.width / 2) - 51 - width1, 11, width1, 28), c2);
        GUI.Box(new Rect((Screen.width / 2) - 50 - (Screen.width / 10) - 2, 10, (Screen.width / 10) + 2, 30), score1.ToString(), style: "ScoreBGLeft");
    }

    public static void DrawColor(Rect position, Color color)
    {
        var backgroundColor = GUI.backgroundColor;
        GUI.backgroundColor = color;
        GUI.Box(position, GUIContent.none, textureStyle);
        GUI.backgroundColor = backgroundColor;
    }
}
