using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeCurve : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int leftX;
    public int rightX;
    public int count = 40;
    Vector3[] points;


    private void Start()
    {
        points = new Vector3[count];
        lineRenderer.positionCount = count;
        double xstep = Mathf.Abs(rightX - leftX) / (float)count;
        for (int i = 0; i < count; i++)
        {
            points[i].x = (float)(leftX + xstep * i);
            points[i].y = Mathf.Pow(2.5f * points[i].x,3) - (2.5f * points[i].x);
            points[i].z = 0;
        }

        lineRenderer.SetPositions(points);
    }

}
