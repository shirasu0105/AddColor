using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLimitManager : MonoBehaviour
{
    [SerializeField] GameObject FrontTimeLimitBar;
    [SerializeField] RectTransform canvas;
    [SerializeField] RectTransform BackTimeLimitBar;

    bool timeLimitFlag;

    public IEnumerator StartTimeLimit()
    {
        timeLimitFlag = true;
        FrontTimeLimitBar.GetComponent<RectTransform>().offsetMax = new Vector2(0f, -35f);
        float difference = 0f;
        float timeLimit = 20.0f;
        float barTimeLimit = canvas.sizeDelta.x - Mathf.Abs(BackTimeLimitBar.GetComponent<RectTransform>().offsetMax.x　* 2);
        float countDown = timeLimit;

        Debug.Log("difference" + difference);
        Debug.Log("timeLimit" + timeLimit);

        while (countDown > 0)
        {
            if(timeLimitFlag == false)
            {
                Debug.Log("フラグfalse");
                yield break;
            }
            difference = countDown;
            countDown -= Time.deltaTime;
            difference -= countDown;
            FrontTimeLimitBar.GetComponent<RectTransform>().offsetMax -= new Vector2(difference * (barTimeLimit/ timeLimit), 0f);
            yield return null;
        }
        Debug.Log("制限時間だよ");
    }

    public void StopTimeLimit()
    {
        timeLimitFlag = false;
    }
}
