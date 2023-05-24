using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeTangent : MonoBehaviour
{

    LineRenderer lineRenderer;
    Vector3[] points = new Vector3[3];
    Transform pointer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        pointer = transform.parent.Find("Pointer");
    }

    public void maketangent()
    {
        Debug.Log("Tangent Changed");
        points[1] = pointer.localPosition; 
        float leftx = pointer.localPosition.x - 0.2f;
        float rightx = pointer.localPosition.x + 0.2f;
        float z = pointer.localPosition.z;

        points[0] = new Vector3(leftx, 2.5f * (3 * Mathf.Pow(pointer.localPosition.x * 2.5f, 2) - 1) * (leftx - pointer.localPosition.x) + pointer.localPosition.y, z);
        points[2] = new Vector3(rightx, 2.5f * (3 * Mathf.Pow(pointer.localPosition.x * 2.5f, 2) - 1) * (rightx - pointer.localPosition.x) + pointer.localPosition.y, z);

        lineRenderer.positionCount = points.Length;
        lineRenderer.SetPositions(points);
    }
}
