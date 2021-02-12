using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartManager : MonoBehaviour
{
    [SerializeField] GameManager GameManager;
    [SerializeField] AnimationManager AnimationManager;

    public void OnClick()
    {
        StartCoroutine(ClickReStart());
    }

    IEnumerator ClickReStart()
    {
        yield return AnimationManager.FadeOut();
        GameManager.ReStart();
    }
}
