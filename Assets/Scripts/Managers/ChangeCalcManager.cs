using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCalcManager : MonoBehaviour
{
    [SerializeField] AudioSource ChangeCalc;
    [SerializeField] Image MixList;
    [SerializeField] Sprite Add;
    [SerializeField] Sprite Sub; 
    [SerializeField] MoveManager MoveManager;

    public void OnClick()
    {
        ChangeCalc.Play();
        if (MoveManager.move.calcFlag == 0)
        {
            MoveManager.move.calcFlag = 1;
            MixList.sprite = Sub;
        }
        else
        {
            MoveManager.move.calcFlag = 0;
            MixList.sprite = Add;
        }
    }
}
