using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliderValueModifier4MinDistance : MonoBehaviour
{
    
    RadialView radialView;
    PinchSlider slider;

    private void Start()
    {
        radialView = GameObject.Find("MainMenu_UI").GetComponent<RadialView>();
        slider = GetComponent<PinchSlider>();
    }

    public void Update()
    {
        radialView.MinDistance = (float)(slider.SliderValue * 0.4f) + 0.4f;
    }
}
