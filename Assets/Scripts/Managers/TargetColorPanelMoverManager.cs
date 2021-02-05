using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetColorPanelMoverManager : MonoBehaviour
{
    [SerializeField] TargetColorPanel TargetColorPanel;

    Vector2[] targetPanelCoordinateList = new Vector2[5];

    private void Awake()
    {

        //座標リストの初期化
        float playPanelCoordinateRead = -360.0f;
        float playPanelCoordinateSense = 250.0f;

        for (int i = 0; i < 5; i++)
        {
            targetPanelCoordinateList[i] = new Vector2(playPanelCoordinateRead + (playPanelCoordinateSense * i), 0);
            Debug.Log(targetPanelCoordinateList[i]);
        }
    }

    public void ColorPanelIns(GameObject ins, int i)
    {
        ins.transform.localPosition = new Vector3(targetPanelCoordinateList[i].x, targetPanelCoordinateList[i].y, 0);
    }

    public void ColorPanelMove(GameObject ins, int coordinate, int targetCoordinate, Action callback)
    {
        StartCoroutine(Move());

        IEnumerator Move()
        {

            yield return StartCoroutine(ins.GetComponent<ColorPanelMoverController>().MoveColorPanel(targetPanelCoordinateList[coordinate], targetPanelCoordinateList[targetCoordinate]));

            callback();
        }
    }
}
