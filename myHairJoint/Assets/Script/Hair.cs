using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hair : MonoBehaviour
{
    public HingeJoint joint;

    public void SetRigidBody(Rigidbody _rigidbody)
    {
        joint.connectedBody = _rigidbody;
    }
}
