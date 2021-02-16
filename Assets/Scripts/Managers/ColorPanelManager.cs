using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPanelManager : MonoBehaviour
{
    [SerializeField] GameObject FlickPanel;
    [SerializeField] GameObject PlayColorPanelPref;
    [SerializeField] Transform Parent;
    [SerializeField] GameManager GameManager;
    [SerializeField] MoveManager MoveManager;
    [SerializeField] ColorPanelMoverManager ColorPanelMoverManager;


    public PlayColorPanelController[] playColorPanelControllers { get; set; } = new PlayColorPanelController[16];
    private PlayColorPanelController[] destroyPref = new PlayColorPanelController[16];

    public bool isMovingColorPanel { get; private set; }

    //ゲームオーバー時初期化
    public IEnumerator InitializationColorPanel()
    {
        for (int i = 0; i < playColorPanelControllers.Length; i++)
        {
            if (playColorPanelControllers[i] != null)
            {
                playColorPanelControllers[i].Destruction();
            }
            playColorPanelControllers[i] = null;
        }
        yield break;
    }

    //余分なプレハブを削除
    public void DestroyColorPanel()
    {
        for (int i = 0; i < destroyPref.Length; i++)
        {
            if(destroyPref[i] != null)
            {
                destroyPref[i].Destruction();
                destroyPref[i] = null;
            }
           
        }
    }

    //空いてるところにプレハブ生成
    public void InsColorPanel()
    {
        int insColor;
        int insPlace;
        int[] nullPlace = new int[16];
        int count = 0;

        //nullの場所を記憶
        for (int i = 0; i < playColorPanelControllers.Length; i++)
        {
            if (playColorPanelControllers[i] == null)
            {
                nullPlace[count] = i;
                count++;
            }
        }

        insPlace = Random.Range(0, count);

        //ランダム生成する色が、ターゲットと別の色になるまでランダム生成を繰り返す
        do
        {
            insColor = Random.Range(0, MoveManager.move.panelColor.Length);
        }
        while (MoveManager.move.panelColor[insColor] == GameManager.game.nowTargetColor);


        //nullの場所からランダムに選んでプレハブ生成/インスタンス化
        var ins = Instantiate(PlayColorPanelPref, Parent);
        playColorPanelControllers[nullPlace[insPlace]] = ins.GetComponent<PlayColorPanelController>();
        playColorPanelControllers[nullPlace[insPlace]].SetColor(MoveManager.move.panelColor[insColor]);
        ColorPanelMoverManager.ColorPanelIns(ins, nullPlace[insPlace]);

        for (int i = 0; i < playColorPanelControllers.Length; i++)
        {
            //nullの場所を初期化
            nullPlace[i] = 0;
        }
    }

    //インスタンスの移動
    public IEnumerator MoveColorPanel()
    {
        int count = 0;
        int finishCount = 0;
        int destroyCount = 0;

        PlayColorPanelController[] temp = new PlayColorPanelController[16];

        isMovingColorPanel = true;
        FlickPanel.SetActive(false);

            //０から16まで探索
        for (int i = 0; i < playColorPanelControllers.Length; i++)
        {
            //PlayColorPanelControllerが入っていたら
            if (playColorPanelControllers[i] != null)
            {
                int t = 0;
                switch (MoveManager.move.flickDirection)
                {
                    case 0: //左
                        t = i % 4;
                        break;
                    case 1: //右
                        t = (i % 4) + 12;
                        break;
                    case 2: //下
                        t = i - (i % 4);
                        break;
                    case 3: //上
                        t = i + (3 - (i % 4));
                        break;

                }
                ColorPanelMoverManager.ColorPanelMove(playColorPanelControllers[i].gameObject, i, t, () => { finishCount++; });
                count++;

                if(temp[t] != null)
                {
                    playColorPanelControllers[i].SetColor(new ColorCalc().Calc(playColorPanelControllers[i].playColorPanel.myColor,
                        temp[t].playColorPanel.myColor,
                        MoveManager.move.calcFlag
                        ));

                    Debug.Log("変更色：" + playColorPanelControllers[i].playColorPanel.myColor);
                    destroyPref[destroyCount] = temp[t];
                    destroyCount++;
                }
                temp[t] = playColorPanelControllers[i];

            }
        }
        yield return new WaitUntil(() => finishCount == count);
        isMovingColorPanel = false;
        FlickPanel.SetActive(true);

        for (int i = 0; i < playColorPanelControllers.Length; i++)
        {
            playColorPanelControllers[i] = temp[i];
        }
    }

    //プレイカラーパネルの色と現在のターゲットカラーパネルの色が同じかどうか
    public void CheckPanelColor()
    {
        for (int i = 0; i < playColorPanelControllers.Length; i++)
        {
            if(playColorPanelControllers[i] != null)
            {
                if (playColorPanelControllers[i].playColorPanel.myColor == GameManager.game.nowTargetColor)
                {
                    playColorPanelControllers[i].Destruction();
                    StartCoroutine(GameManager.CompleteColor());
                }
            }

        }
    }
}