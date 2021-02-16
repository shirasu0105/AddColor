using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartManager : MonoBehaviour
{
    [SerializeField] AudioSource ButtonSe;
    [SerializeField] GameManager GameManager;
    [SerializeField] AnimationManager AnimationManager;

    public void OnClick()
    {
        ButtonSe.Play();
        StartCoroutine(ClickReStart());
    }

    IEnumerator ClickReStart()
    {
        yield return AnimationManager.FadeOut();
        GameManager.ReStart();
    }
}
