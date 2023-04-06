using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailedRotationConstraint : MonoBehaviour
{
    public float Max;
    public float Min;

    Quaternion quaternion;

    private AxisFlags constraintOnRotation = 0;

    public AxisFlags ConstraintOnRotation
    {
        get => constraintOnRotation;
        set => constraintOnRotation = value;
    }

    void FixedUpdate()
    {
        if (constraintOnRotation.IsMaskSet(AxisFlags.XAxis))
        {
            if (transform.rotation.x > Max)
                transform.rotation = Quaternion.AngleAxis(Max,Vector3.right);

        }
        if (constraintOnRotation.IsMaskSet(AxisFlags.YAxis))
        {
            
        }
        if (constraintOnRotation.IsMaskSet(AxisFlags.ZAxis))
        {
            
        }
    }

}
