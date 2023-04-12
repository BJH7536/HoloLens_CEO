using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleOutline : MonoBehaviour
{
    public GameObject Visible_Light;
    // Start is called before the first frame update
    void Start()
    {
        if(Visible_Light == null) 
            GetComponent<MeshOutline>().enabled = false;
        
    }

}
