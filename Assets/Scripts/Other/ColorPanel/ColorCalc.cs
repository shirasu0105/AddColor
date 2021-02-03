using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCalc
{
    public Color Calc(Color color, Color targetColor, int calcFlag)
    {

        float r = partCalc(color.r, targetColor.r);
        float g = partCalc(color.g, targetColor.g);
        float b = partCalc(color.b, targetColor.b);


        float partCalc(float partColor, float partTargetColor)
        {
            float partCalcedColor;

            if (calcFlag == 0)
            {
                partCalcedColor = partColor + partTargetColor;
                if(partCalcedColor > 1.0f)
                {
                    partCalcedColor = 1.0f;
                    Debug.Log("あ" + partCalcedColor);
                }
            }
            else
            {
                partCalcedColor = partColor * partTargetColor;
            }
            return partCalcedColor;
        }

        Color calcedColor = new Color(r, g, b);

        Debug.Log("計算後：" + calcedColor);

        return calcedColor;
    }
}
