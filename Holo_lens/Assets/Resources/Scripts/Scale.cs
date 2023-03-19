using MRTK.Tutorials.GettingStarted;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (GetComponent<PartAssemblyController>().isPlaced && GetComponent<HingeJoint>() != null)
        {
            transform.localScale = new Vector3(1,1,1);
        }
    }
}
