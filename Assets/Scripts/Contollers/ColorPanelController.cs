using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPanelController : MonoBehaviour
{
    public void MoveColorPanel(Vector2 coordinate, Vector2 targetCoordinate, Action callback)
    {
        StartCoroutine(Move());

        IEnumerator Move()
        {
            float startTime = Time.time;
            float speed = 4000;
            var distance = Vector2.Distance(coordinate, targetCoordinate);
            while (Vector2.Distance(transform.localPosition, targetCoordinate) != 0)
            {
                transform.localPosition = Vector2.Lerp(
                    coordinate,
                    targetCoordinate,
                    (Time.time - startTime) * speed / distance
                    );
                yield return null;
            }
            callback();
        }
    }
}
