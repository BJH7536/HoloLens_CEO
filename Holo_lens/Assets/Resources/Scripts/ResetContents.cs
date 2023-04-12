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
    
    public void ResetContents_() // 대상 콘텐츠의 프리팹을 불러와 대체시킨다.
    {
        MyTargetContents = Managers.Resource.Instantiate(TargetContents.name, TargetContentsParent);

        DestroyImmediate(TargetContents);
        
        TargetContents = MyTargetContents;
    }

}