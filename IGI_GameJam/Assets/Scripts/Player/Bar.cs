using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;


    public void SetMax(int Max)
    {
        slider.maxValue = Max;
        slider.value = Max;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetValue(int Value)
    {
        slider.value = Value;
        fill.color = gradient.Evaluate(slider.normalizedValue);

    }
}
