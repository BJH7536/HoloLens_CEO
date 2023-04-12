using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FindMaterials : MonoBehaviour
{
    GameObject[] objects;

    private void Start()
    {
        objects = GameObject.FindGameObjectsWithTag("BackPlate");
    }

    public void FindMaterialsAndsetTransparent()
    {
        float v = GetComponent<PinchSlider>().SliderValue;

        foreach (var obj in objects)
        {
            Color c1 = obj.GetComponent<MeshRenderer>().material.color;
            obj.GetComponent<MeshRenderer>().material.color = new Color(c1.r, c1.g, c1.b, v);
        }
    }
}
