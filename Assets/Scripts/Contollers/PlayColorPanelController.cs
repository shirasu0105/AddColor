using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayColorPanelController : ColorPanelController
{
    public PlayColorPanel playColorPanel = new PlayColorPanel();

    public void SetColor(Color panelColor)
    {
        playColorPanel.myColor = panelColor;
        gameObject.GetComponent<Image>().color = panelColor;
    }
}