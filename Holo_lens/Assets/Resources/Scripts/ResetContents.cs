using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetContents : MonoBehaviour
{
    public GameObject TargetContents;
    GameObject MyTargetContents;
    Transform TargetContentsParent;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        TargetContents = transform.parent.GetChild(0).gameObject;
        TargetContentsParent = TargetContents.transform.parent;

    }
    
    public void ResetContents_() // ��� �������� �������� �ҷ��� ��ü��Ų��.
    {
        MyTargetContents = Managers.Resource.Instantiate(TargetContents.name, TargetContentsParent);

        DestroyImmediate(TargetContents);
        
        TargetContents = MyTargetContents;
    }

}