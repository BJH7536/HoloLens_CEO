using MRTK.Tutorials.GettingStarted;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteHinge : MonoBehaviour
{
    private void FixedUpdate()
    {
        if(GetComponent<PartAssemblyController>().isPlaced && GetComponent<HingeJoint>() != null )
        {
            Destroy(GetComponent<HingeJoint>());
        }
    }
}
