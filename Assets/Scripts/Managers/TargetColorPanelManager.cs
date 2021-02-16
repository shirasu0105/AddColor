using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetColorPanelManager : MonoBehaviour
{
    [SerializeField] GameManager GameManager;
    [SerializeField] MoveManager MoveManager;
    [SerializeField] GameObject TargetColorPanelPref;
    [SerializeField] Transform Parent;
    [SerializeField] TargetColorPanelMoverManager TargetColorPanelMoverManager;

    public TargetColorPanelController[] targetColorPanelControllers { get; set; } = new TargetColorPanelController[5];

    //ゲームオーバー時初期化
    public IEnumerator InitializationTargetColorPanel()
    {
        for (int i = 0; i < targetColorPanelControllers.Length; i++)
        {
            targetColorPanelControllers[i].Destruction();
            targetColorPanelControllers[i] = null;
        }
        yield break;
    }

    //満タンになるまで順番にプレハブ生成
    public void InsTargetColorPanel()
    {
        for(int i=0;i< targetColorPanelControllers.Length;i++)
        {
            if(targetColorPanelControllers[i] == null)
            {
                var ins = Instantiate(TargetColorPanelPref, Parent);
                targetColorPanelControllers[i] = ins.GetComponent<TargetColorPanelController>();
                targetColorPanelControllers[i].SetColor(MoveManager.move.panelColor[Random.Range(0, MoveManager.move.panelColor.Length)]);
                TargetColorPanelMoverManager.ColorPanelIns(ins, i);
            }
        }
        SetTargetColor();
    }

    //インスタンスの移動
    public IEnumerator MoveTargetColorPanel()
    {
        int count = 0;
        int finishCount = 0;

        TargetColorPanelController[] temp = new TargetColorPanelController[16];

        targetColorPanelControllers[0].Destruction();
        targetColorPanelControllers[0] = null;

        for (int i = 1; i < targetColorPanelControllers.Length; i++)
        {
            TargetColorPanelMoverManager.ColorPanelMove(targetColorPanelControllers[i].gameObject, i, i -1, () => { finishCount++; });
            count++;

            //targetColorPanelControllers[i].SetColor(targetColorPanelControllers[i].targetColorPanel.myColor);

            Debug.Log("変更色：" + targetColorPanelControllers[i].targetColorPanel.myColor);
            temp[i-1] = targetColorPanelControllers[i];
        }

        yield return new WaitUntil(() => finishCount == count);

        for (int i = 0; i < targetColorPanelControllers.Length; i++)
        {
            targetColorPanelControllers[i] = temp[i];
        }
    }

    private void SetTargetColor()
    {
        GameManager.game.nowTargetColor = targetColorPanelControllers[0].targetColorPanel.myColor;
    }
}
