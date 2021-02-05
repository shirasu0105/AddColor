using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetColorPanelController : ColorPanelController
{
    public TargetColorPanel targetColorPanel = new TargetColorPanel();

    public void SetColor(Color panelColor)
    {
        targetColorPanel.myColor = panelColor;
        gameObject.GetComponent<Image>().color = panelColor;
    }
}