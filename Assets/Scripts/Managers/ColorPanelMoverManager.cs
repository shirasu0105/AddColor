using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPanelMoverManager : MonoBehaviour
{
    [SerializeField] ColorPanelManager ColorPaneManager;


    //プレイ及びターゲットカラーパネルの座標リスト
    Vector2[] playPanelCoordinateList = new Vector2[16];

    private void Awake()
    {

        //座標リストの初期化
        float playPanelCoordinateRead = -360.0f;
        float playPanelCoordinateSense = 240.0f;
        int count = 0;

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                playPanelCoordinateList[count] = new Vector2(playPanelCoordinateRead + (playPanelCoordinateSense * i), playPanelCoordinateRead + (playPanelCoordinateSense * j));
                Debug.Log(playPanelCoordinateList[count]);
                count++;
            }
        }
    }
    
    public void ColorPanelIns(GameObject ins, int i)
    {
        ins.transform.localPosition = new Vector3(playPanelCoordinateList[i].x, playPanelCoordinateList[i].y, 0);
    }
    
    public void ColorPanelMove(GameObject ins, int coordinate, int targetCoordinate, Action callback)
    {
        StartCoroutine(Move());

        IEnumerator Move()
        {

            yield return StartCoroutine(ins.GetComponent<ColorPanelMoverController>().MoveColorPanel(playPanelCoordinateList[coordinate], playPanelCoordinateList[targetCoordinate]));

            callback();
        }
    }
}
