using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetContents : MonoBehaviour
{
    public GameObject TargetContents;
    GameObject MyTargetContents;
    Transform TargetContentsParent;
    Vector3 OriginPos;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        TargetContentsParent = TargetContents.transform.parent;
        OriginPos = TargetContents.transform.position;
    }
    
    public void ResetContents_() // ��� �������� �������� �ҷ��� ��ü��Ų��.
    {
        MyTargetContents = Managers.Resource.Instantiate(TargetContents.name, TargetContentsParent);
        MyTargetContents.transform.position = OriginPos;

        DestroyImmediate(TargetContents);
        
        TargetContents = MyTargetContents;
    }

}