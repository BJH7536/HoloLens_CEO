using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
public class StencilController : MonoBehaviour
{

    public Material[] mat =new Material[2];
    int i = 0;
    //Material�� �ٲ��ش�.
    public void ChangeCubeMat() 
    {
        i = ++i % 2;

        gameObject.GetComponent<MeshRenderer>().material = mat[i];
    }

}
