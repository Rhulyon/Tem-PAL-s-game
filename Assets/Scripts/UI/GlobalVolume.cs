using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GlobalVolume : MonoBehaviour
{
    private Slider slider;

    public void Awake()
    {
        slider = this.GetComponent<Slider>();
    }

    private void OnSliderChange(float arg0)
    {
        AudioListener.volume = slider.value;
    }

    void OnEnable()
    {
        slider.value = AudioListener.volume;

        slider.onValueChanged.AddListener(OnSliderChange);
    }

    private void OnDisable()
    {
        slider.onValueChanged.RemoveListener(OnSliderChange);
    }

}
