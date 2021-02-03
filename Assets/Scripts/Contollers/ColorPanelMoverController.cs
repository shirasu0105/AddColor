using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPanelMoverController : MonoBehaviour
{
    public IEnumerator MoveColorPanel(Vector2 coordinate, Vector2 targetCoordinate)
    {
        float startTime = Time.time;
        float speed = 4000;
        var distance = Vector2.Distance(coordinate, targetCoordinate);
        Debug.Log("元距離：" + distance);
        Debug.Log("先距離：" + Vector2.Distance(transform.localPosition, targetCoordinate));
        while (Vector2.Distance(transform.localPosition, targetCoordinate) != 0.0f)
        {
            transform.localPosition = Vector2.Lerp(
                coordinate,
                targetCoordinate,
                (Time.time - startTime) * speed / distance
                );
            yield return null;
        }
    }
}
