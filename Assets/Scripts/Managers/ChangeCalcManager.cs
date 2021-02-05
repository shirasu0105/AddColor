using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCalcManager : MonoBehaviour
{
    [SerializeField] Image ChangeCalcButton;
    [SerializeField] Sprite Add;
    [SerializeField] Sprite Sub; 
    [SerializeField] MoveManager MoveManager;

    public void OnClick()
    {
        if (MoveManager.move.calcFlag == 0)
        {
            MoveManager.move.calcFlag = 1;
            ChangeCalcButton.sprite = Sub;
        }
        else
        {
            MoveManager.move.calcFlag = 0;
            ChangeCalcButton.sprite = Add;
        }
        Debug.Log("かるくふらぐ：" + MoveManager.move.calcFlag);
    }
}
