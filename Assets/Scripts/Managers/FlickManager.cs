using UnityEngine;

public class FlickManager : MonoBehaviour
{
    [SerializeField] MoveManager MoveManager;

    private Vector2 startPos;
    private Vector2 endPos;


    public void OnPointerDown()
    {
        startPos = Input.mousePosition;
    }

    public  void OnPointerUp()
    {
        endPos = Input.mousePosition;
        Flick();
    }

    public void Flick()
    {
        if (Mathf.Abs(startPos.x - endPos.x) > Mathf.Abs(startPos.y - endPos.y))
        {
            if (startPos.x > endPos.x)
            {
                StartCoroutine(MoveManager.Move(0));
                Debug.Log("左");
            }
            else
            {
                StartCoroutine(MoveManager.Move(1));
                Debug.Log("右");
            }
        }
        else
        {
            if (startPos.y > endPos.y)
            {
                StartCoroutine(MoveManager.Move(2));
                Debug.Log("下");
            }
            else
            {
                StartCoroutine(MoveManager.Move(3));
                Debug.Log("上");
            }
        }
        startPos = new Vector2(0, 0);
        endPos = new Vector2(0, 0);
    }
}
