using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPanelManager : MonoBehaviour
{
    [SerializeField] GameObject FlickPanel;
    [SerializeField] GameObject PlayColorPanelPref;
    [SerializeField] Transform Parent;

    public PlayColorPanelController[] playColorPanelControllers = new PlayColorPanelController[16];

    //プレイ及びターゲットカラーパネルの座標リスト
    Vector2[] playPanelCoordinateList = new Vector2[16];


    private void Start()
    {
        for(int i=0;i< playColorPanelControllers.Length; i++)
        {
            playColorPanelControllers[i] = null;
        }

        //座標リストの初期化
        float playPanelCoordinateRead = -360.0f;
        float playPanelCoordinateSense = 240.0f;
        int count = 0;

        for (int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                playPanelCoordinateList[count] = new Vector2(playPanelCoordinateRead + (playPanelCoordinateSense * i), playPanelCoordinateRead + (playPanelCoordinateSense * j));
                Debug.Log(playPanelCoordinateList[count]);
                count++;
            }
        }
    }

    public void InsColorPanel()
    {
        int insPlace;
        int[] nullPlace = new int[16];
        int count=0;

        for (int i = 0; i < playPanelCoordinateList.Length; i++)
        {
            if (playColorPanelControllers[i] == null)
            {
                nullPlace[count] = i;
                count++;
            }
        }

        insPlace = Random.Range(0, count-1);
        var ins = Instantiate(PlayColorPanelPref,Parent);
        ins.name = nullPlace[insPlace].ToString();
        ins.transform.localPosition = new Vector3(playPanelCoordinateList[nullPlace[insPlace]].x, playPanelCoordinateList[nullPlace[insPlace]].y, 0);
        playColorPanelControllers[nullPlace[insPlace]] = ins.GetComponent<PlayColorPanelController>();


        for (int i = 0; i < playPanelCoordinateList.Length; i++)
        {
            nullPlace[i] = 0;
            //Debug.Log(i + "：" + playColorPanelControllers[i]);
        }
    }

    public IEnumerator MoveColorPanel(int flickDire)
    {
        int count = 0;
        int finishCount = 0;

        yield return new WaitUntil(() => finishCount == count);
    }
}