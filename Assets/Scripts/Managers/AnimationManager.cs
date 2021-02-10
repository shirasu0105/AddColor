using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] Animator StartCountDown; //スタートカウントダウン
    [SerializeField] Animator FadeInAnim;
    [SerializeField] Animator FadeOutAnim;

    public IEnumerator GameStartAnim()
    {
        StartCountDown.gameObject.SetActive(true);
        yield return new WaitForSeconds(4);
        StartCountDown.gameObject.SetActive(false);
    }

    public IEnumerator FadeIn()
    {
        FadeInAnim.gameObject.SetActive(true);
        FadeInAnim.Play("FadeIn");
        yield return new WaitForSeconds(1);
        FadeInAnim.gameObject.SetActive(false);
    }

    public IEnumerator FadeOut()
    {
        FadeInAnim.gameObject.SetActive(true);
        FadeInAnim.Play("FadeOut");
        yield return new WaitForSeconds(1);
        FadeInAnim.gameObject.SetActive(false);
    }
}
