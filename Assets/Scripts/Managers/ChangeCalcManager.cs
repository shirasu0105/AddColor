using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCalcManager : MonoBehaviour
{

    [SerializeField] MoveManager MoveManager;

    public void OnClick()
    {
        if (MoveManager.move.calcFlag == 0)
        {
            MoveManager.move.calcFlag = 1;
        }
        else
        {
            MoveManager.move.calcFlag = 0;
        }
        Debug.Log("かるくふらぐ：" + MoveManager.move.calcFlag);
    }
}
