using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Description;
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] AnimationManager AnimationManager;
    [SerializeField] MoveManager MoveManager;
    [SerializeField] ColorPanelManager ColorPanelManager;
    [SerializeField] TargetColorPanelManager TargetColorPanelManager;
    [SerializeField] ScoreManager ScoreManager;
    [SerializeField] TimeLimitManager TimeLimitManager;
    [SerializeField] SaveManager SaveManager;

    public Game game = new Game();

    //スコアとターゲットカラーの初期化
    private void Awake()
    {
        game.SetGameStatus();
    }
    
    
    void Start()
    {
        SaveManager.LoadDataFromLocal();
        if (SaveManager.SaveDate.firstPlay == true)
        {
            StartCoroutine(AnimationManager.FadeIn());
            Description.SetActive(true);
            //SaveManager.SaveDate.firstPlay = false;
            SaveManager.SaveDataToLocal();
        }
        else
        {
            StartCoroutine(GameStart());
        }
    }

    public void ReStart()
    {
        StartCoroutine(GameStart());
    }

    //色が揃ったとき
    public IEnumerator CompleteColor()
    {
        StartCoroutine(AnimationManager.CompleteEffect());
        ScoreManager.PlusScore();
        yield return StartCoroutine(TargetColorPanelManager.MoveTargetColorPanel());
        TargetColorPanelManager.InsTargetColorPanel();
        yield return StartCoroutine(TimeLimitManager.StopTimeLimit());
        StartCoroutine(TimeLimitManager.StartTimeLimit());
    }

    //ゲームスタート
    public IEnumerator GameStart()
    {
        game.gameOver = false;
        Description.SetActive(false);
        GameOverPanel.gameObject.SetActive(false);
        StartCoroutine(AnimationManager.FadeIn());
        ScoreManager.SetScore();
        Debug.Log("こるーちんよぶまえ");
        yield return AnimationManager.StartCountDown();
        MoveManager.SetMove();
        TargetColorPanelManager.InsTargetColorPanel();
        StartCoroutine(TimeLimitManager.StartTimeLimit());
    }

    //ゲームオーバー
    public IEnumerator GameOver()
    {
        game.gameOver = true;
        ScoreManager.BestScoreUpdate();
        ScoreManager.SetCurrentScoreText();
        yield return ColorPanelManager.InitializationColorPanel();
        yield return TargetColorPanelManager.InitializationTargetColorPanel();
        GameOverPanel.gameObject.SetActive(true);
    }
}
