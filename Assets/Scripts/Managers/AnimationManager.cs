using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] Animator StartCountDown; //スタートカウントダウン

    public IEnumerator GameStartAnim()
    {
        StartCountDown.gameObject.SetActive(true);
        yield return new WaitForSeconds(4);
        StartCountDown.gameObject.SetActive(false);
    }
}
