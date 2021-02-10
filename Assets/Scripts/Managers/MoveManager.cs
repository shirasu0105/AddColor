using System.Collections;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    [SerializeField] GameManager GameManager;
    [SerializeField] ColorPanelManager ColorPanelManager;
    [SerializeField] FlickManager FlickManager;

    public Move move = new Move();

    private void Awake()
    {
        move.SetPanelColor();
    }
    public void SetMove()
    {
        ColorPanelManager.InsColorPanel();
    }

    public IEnumerator Move()
    {
        yield return StartCoroutine(ColorPanelManager.MoveColorPanel());
        if(GameManager.game.gameOver == true)
        {
            Debug.Log("ゲームオーバーフラグ");
            yield break;
        }
        ColorPanelManager.DestroyColorPanel();
        ColorPanelManager.InsColorPanel();
        ColorPanelManager.CheckPanelColor();
    }
}