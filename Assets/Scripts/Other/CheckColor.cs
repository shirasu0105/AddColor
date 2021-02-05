using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColor
{
    public bool Check(Color playPanelColor, Color targetPanelColor)
    {
        if (playPanelColor == targetPanelColor)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
