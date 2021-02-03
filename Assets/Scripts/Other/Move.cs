using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    public int moveCount;
    public int flickDirection;
    public int calcFlag;

    public Color[] panelColor = new Color[8];

    public void SetPanelColor()
    {
        panelColor[0] = new Color(1.0f, 1.0f, 1.0f); //白
        panelColor[1] = new Color(1.0f, 0f, 0f); //赤
        panelColor[2] = new Color(0f, 1.0f, 0f); //緑
        panelColor[3] = new Color(0f, 0f, 1.0f); //青
        panelColor[4] = new Color(0f, 1.0f, 1.0f); //シアン
        panelColor[5] = new Color(1.0f, 0f, 1.0f); //マゼンタ
        panelColor[6] = new Color(1.0f, 1.0f, 0f); //イエロー
        panelColor[7] = new Color(0f, 0f, 0f); //黒
    }
}
