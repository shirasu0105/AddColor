using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTitleManager : MonoBehaviour
{
    [SerializeField] AnimationManager AnimationManager;

    public void OnCkick()
    {
        StartCoroutine(ClickToTitle());
    }

    IEnumerator ClickToTitle()
    {
        yield return AnimationManager.FadeOut();
        SceneManager.LoadScene(0);
    }
}
