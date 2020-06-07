using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hair : MonoBehaviour
{
    [SerializeField]
    FixedJoint _joint;
   

    public void SetRigidBody(Rigidbody _rigidbody)
    {
        _joint.connectedBody = _rigidbody;
    }

    public static float GetAngle(Vector3 from, Vector3 to)
    {
        Vector3 v = to - from;
        return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
    }

}
