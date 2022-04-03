using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBar : MonoBehaviour
{
    private Slider slider;
    private float currentValue = 0f;
    public float CurrentValue  {
        get { return currentValue; }
        set {
            currentValue = value;
            slider.value = currentValue;
        }
    }

    private void Start() {
        slider = gameObject.GetComponent<Slider>();
        CurrentValue = 0f;
    }
}
