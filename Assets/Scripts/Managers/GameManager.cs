using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] AnimationManager AnimationManager;
    [SerializeField] MoveManager MoveManager;
    [SerializeField] ColorPanelManager ColorPanelManager;
    [SerializeField] TargetColorPanelManager TargetColorPanelManager;
    [SerializeField] ScoreManager ScoreManager;
    [SerializeField] TimeLimitManager TimeLimitManager;

    public Game game = new Game();

    //スコアとターゲットカラーの初期化
    private void Awake()
    {
        game.SetGameStatus();
    }
    
    
    void Start()
    {
        StartCoroutine(GameStart());
    }

    //色が揃ったとき
    public IEnumerator CompleteColor()
    {
        ScoreManager.PlusScore();
        yield return StartCoroutine(TargetColorPanelManager.MoveTargetColorPanel());
        TargetColorPanelManager.InsTargetColorPanel();
        TimeLimitManager.StopTimeLimit();
        yield return new WaitForSeconds(1f);
        StartCoroutine(TimeLimitManager.StartTimeLimit());

    }

    //ゲームスタート
    public IEnumerator GameStart()
    {
        ScoreManager.SetScoreText();
        yield return AnimationManager.GameStartAnim();
        MoveManager.SetMove();
        TargetColorPanelManager.InsTargetColorPanel();
        StartCoroutine(TimeLimitManager.StartTimeLimit());
    }
}
