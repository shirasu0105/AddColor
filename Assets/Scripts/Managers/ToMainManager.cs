using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainManager : MonoBehaviour
{

    [SerializeField] Animator FadeOutAnim;
    public void OnPointerClick()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        FadeOutAnim.gameObject.SetActive(true);
        FadeOutAnim.Play("FadeOut");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}
