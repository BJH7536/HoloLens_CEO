using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliderValueModifier4Height : MonoBehaviour
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
        radialView.FixedVerticalPosition = (slider.SliderValue - 1.0f) / 3;

        if (radialView.FixedVerticalPosition <= -0.2f)
            radialView.FixedVerticalPosition = -0.2f;

        if (radialView.FixedVerticalPosition >= 0)
            radialView.FixedVerticalPosition = 0;

    }
}
