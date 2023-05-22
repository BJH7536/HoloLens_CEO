using MRTK.Tutorials.GettingStarted;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteHingepart1 : MonoBehaviour
{
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        if (GetComponent<PartAssemblyPart1>().isPlaced && GetComponent<HingeJoint>() != null)
        {
            Destroy(GetComponent<HingeJoint>());
        }
    }
}
