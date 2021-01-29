using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPanelManager : MonoBehaviour
{
    [SerializeField] GameObject PlayColorPanelPref;
    [SerializeField] Transform Parent;

    public PlayColorPanelController[] playColorPanelControllers = new PlayColorPanelController[16];
    public TargetColorPanelController[] targetColorPanelController = new TargetColorPanelController[6];

    //プレイ及びターゲットカラーパネルの座標リスト
    Vector2[] playPanelCoordinateList = new Vector2[16];
    Vector2[] targetPanelCoordinateList = new Vector2[6];


    private void Start()
    {
        //座標リストの初期化
        int playPanelCoordinateRead = -360;
        int playPanelCoordinateSense = 240;
        int count = 0;

        for (int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                playPanelCoordinateList[count] = new Vector2(playPanelCoordinateRead + (playPanelCoordinateSense * i), playPanelCoordinateRead + (playPanelCoordinateSense * j));
                count++;
            }
        }
    }

    public void InsColorPanel()
    {
        int insPlace=0;
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
        count = 0;
        var ins = Instantiate(
        PlayColorPanelPref,
        Parent);
        ins.transform.localPosition = new Vector3(playPanelCoordinateList[nullPlace[insPlace]].x, playPanelCoordinateList[nullPlace[insPlace]].y, 0);
        playColorPanelControllers[nullPlace[insPlace]] = ins.GetComponent<PlayColorPanelController>();
        Debug.Log("あ" + nullPlace[insPlace]);


        for (int i = 0; i < playPanelCoordinateList.Length; i++)
        {
            nullPlace[i] = 0;
        }

    }

    public IEnumerator MoveColorPanel(int flickDire)
    {
        int count = 0;
        int finishCount = 0;

        for(int i=0;i< playColorPanelControllers.Length; i++)
        {
            if (playColorPanelControllers[i] != null)
            {
                int t = 0;
                switch (flickDire)
                {
                    case 0: //左
                        t = i % 4;
                        break;
                    case 1: //右
                        t = (i % 4) + 12;
                        break;
                    case 2: //下
                        t = i / 4 * 4;
                        break;
                    case 3: //上
                        t = i / 4 * 4 + 3;
                        break;

                }
                playColorPanelControllers[i].MoveColorPanel(playPanelCoordinateList[i], playPanelCoordinateList[t], () => { finishCount++; });
            }
        }

        yield return new WaitUntil(() => finishCount == count);
    }
}