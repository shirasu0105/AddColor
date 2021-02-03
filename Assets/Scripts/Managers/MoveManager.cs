using System.Collections;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    [SerializeField] ColorPanelManager ColorPanelManager;
    [SerializeField] FlickManager FlickManager;

    public Move move = new Move();


    private void Start()
    {
        move.SetPanelColor();
        ColorPanelManager.InsColorPanel();
    }

    public IEnumerator Move()
    {
        yield return StartCoroutine(ColorPanelManager.MoveColorPanel());
        ColorPanelManager.DestroyColorPanel();
        ColorPanelManager.InsColorPanel();
    }
}