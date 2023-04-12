using MRTK.Tutorials.GettingStarted;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeItStuckToHint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains(this.gameObject.name) && other.gameObject.name.Contains("hint"))
        {
            this.gameObject.transform.rotation = other.gameObject.transform.rotation;
            this.gameObject.transform.position = other.gameObject.transform.position;
            this.GetComponent<PartAssemblyController>().CheckPlacement();
        }
    }
}

