using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text ScoreText;
    [SerializeField] Text BestScoreText;
    [SerializeField] Text CurrentScoreText;
    [SerializeField] SaveManager SaveManager;

    const int Initial = 0;
    int score;
    int bestScore = Initial;

    public void SetScore()
    {
        SaveManager.LoadDataFromLocal();
        score = 0;
        bestScore = SaveManager.SaveDate.bestScore;
        SetScoreText();
    }

    public void SetScoreText()
    {
        ScoreText.text = score.ToString();
        BestScoreText.text = bestScore.ToString();
    }

    public void SetCurrentScoreText()
    {
        CurrentScoreText.text = score.ToString();
    }

    //色が揃ったときスコア上昇
    public void PlusScore()
    {
        score += 10;
        SetScoreText();
    }

    //ベストスコアの更新
    public void BestScoreUpdate()
    {
        SaveManager.LoadDataFromLocal();
        if(SaveManager.SaveDate.bestScore < score)
        {
            SaveManager.SaveDate.bestScore = score;
        }
        SaveManager.SaveDataToLocal();
    }
}
