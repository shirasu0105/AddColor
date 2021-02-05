using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text ScoreText;

    //スコアの初期化
    const int Initial = 0;
    public int score { get; private set; } = Initial;

    public void SetScoreText()
    {
        ScoreText.text = score.ToString();
    }

    //色が揃ったときスコア上昇
    public void PlusScore()
    {
        score += 10;
        SetScoreText();
    }
}