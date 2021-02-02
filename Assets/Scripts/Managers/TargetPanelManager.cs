using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPanelManager : MonoBehaviour
{
    public TargetColorPanelController[] targetColorPanelController = new TargetColorPanelController[6];

    Vector2[] targetPanelCoordinateList = new Vector2[6];

    private void Start()
    {
        //座標リストの初期化
        float targetPanelCoordinateRead = -360.0f;
        float targetPanelCoordinateSense = 240.0f;
        int count = 0;

        for (int i = 0; i < 6; i++)
        {
            targetPanelCoordinateList[count] = new Vector2(targetPanelCoordinateRead + (targetPanelCoordinateSense * i), -500.0f);
            count++;
        }
    }

}
