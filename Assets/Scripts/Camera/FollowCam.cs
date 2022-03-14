using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;
    public bool IsFollow = true;


    // Update is called once per frame
    void Update()
    {
        if(IsFollow)
        {
            transform.position = Target.position + Offset;
        }
    }
}
