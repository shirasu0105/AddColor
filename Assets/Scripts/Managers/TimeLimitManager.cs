using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLimitManager : MonoBehaviour
{
    [SerializeField] ColorPanelManager ColorPanelManager;
    [SerializeField] GameManager GameManager;
    [SerializeField] GameObject FrontTimeLimitBar;
    [SerializeField] RectTransform canvas;
    [SerializeField] RectTransform BackTimeLimitBar;

    bool isMovingTimeLimit;

    public IEnumerator StartTimeLimit()
    {
        isMovingTimeLimit = true;
        FrontTimeLimitBar.GetComponent<RectTransform>().offsetMax = new Vector2(0f, -35f);
        float difference = 0f;
        float timeLimit = 20.0f;
        float barTimeLimit = 1000;
        float countDown = timeLimit;

        while (countDown > 0)
        {
            if(isMovingTimeLimit == false)
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
        Debug.Log("制限時間");
        yield return new WaitWhile(() => ColorPanelManager.isMovingColorPanel);
        yield return GameManager.GameOver();
    }

    public IEnumerator StopTimeLimit()
    {
        isMovingTimeLimit = false;
        yield break;
    }
}
