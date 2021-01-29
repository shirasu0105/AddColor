using System.Collections;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    [SerializeField] ColorPanelManager ColorPanelManager;
    [SerializeField] FlickManager FlickManager;

    public int move { get; private set; } = 1;

    private void Start()
    {
        ColorPanelManager.InsColorPanel();
    }

    public IEnumerator Move(int flickDirection)
    {
        yield return ColorPanelManager.MoveColorPanel(flickDirection);
        ColorPanelManager.InsColorPanel();
    }
}