using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class movingPointer : MonoBehaviour
{
    public Transform pointer;
    float z;

    void Start()
    {
        z = pointer.localPosition.z;
    }

    public void SyncPointerandValue(SliderEventData sliderEventData)
    {
        float x = sliderEventData.NewValue - 0.5f;
        pointer.localPosition = new Vector3(x, Mathf.Pow(2.5f * x,3) - (2.5f * x), z);
    }
}
