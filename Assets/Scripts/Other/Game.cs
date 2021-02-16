using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    public Color nowTargetColor;
    public bool gameOver = false;

    public void SetGameStatus()
    {
        nowTargetColor = new Color(0f, 0f, 0f);
    }
}