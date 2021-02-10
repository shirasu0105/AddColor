using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartManager : MonoBehaviour
{
    [SerializeField] GameManager GameManager;

    public void OnClick()
    {
        GameManager.ReStart();
    }
}
