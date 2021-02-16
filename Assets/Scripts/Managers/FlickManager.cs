using UnityEngine;

public class FlickManager : MonoBehaviour
{
    [SerializeField] AudioSource FlickSe;
    [SerializeField] MoveManager MoveManager;

    private Vector2 startPos;
    private Vector2 endPos;


    //タップしたとき
    public void OnPointerDown()
    {
        //タップした位置を取得
        startPos = Input.mousePosition;
    }

    //指を離したとき
    public  void OnPointerUp()
    {
        //離した位置を取得
        endPos = Input.mousePosition;
        Flick();
    }

    //タップ及び離した位置からフリック方向を取得
    public void Flick()
    {
        FlickSe.Play();
        if (Mathf.Abs(startPos.x - endPos.x) > Mathf.Abs(startPos.y - endPos.y))
        {
            if (startPos.x > endPos.x)
            {
                MoveManager.move.flickDirection = 0;
                Debug.Log("左");
            }
            else
            {
                MoveManager.move.flickDirection = 1;
                Debug.Log("右");
            }
        }
        else
        {
            if (startPos.y > endPos.y)
            {
                MoveManager.move.flickDirection = 2;
                Debug.Log("下");
            }
            else
            {
                MoveManager.move.flickDirection = 3;
                Debug.Log("上");
            }
        }
        StartCoroutine(MoveManager.Move());

        startPos = new Vector2(0, 0);
        endPos = new Vector2(0, 0);
    }
}
