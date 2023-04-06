using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    Vector3 OriginPos;
    Quaternion OriginRot;
    Transform _player;

    void Start()
    {
        OriginPos = transform.position;
        OriginRot = transform.rotation;
        _player = GameObject.Find("Main Camera").transform;
    }

    private void FixedUpdate()
    {
         if ((_player.position - transform.position).magnitude < 2.0f)
        {
            transform.LookAt(_player.position);
        }
         else
        {
            transform.position = OriginPos;
            transform.rotation = OriginRot;
        }
    }

}
