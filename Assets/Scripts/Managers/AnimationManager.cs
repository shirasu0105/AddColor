using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] Animator StartCountDownAnim; //スタートカウントダウン
    [SerializeField] Animator FadeInAnim;
    [SerializeField] Animator FadeOutAnim;
    [SerializeField] Animator CompleteAnim;

    public IEnumerator StartCountDown()
    {
        StartCountDownAnim.gameObject.SetActive(true);
        yield return new WaitForSeconds(4);
        StartCountDownAnim.gameObject.SetActive(false);
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

    public IEnumerator CompleteEffect()
    {
        CompleteAnim.gameObject.SetActive(true);
        yield return new WaitForSeconds(.6f);
        CompleteAnim.gameObject.SetActive(false);
    }
}
