using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public GameObject _Body;

    public void SetRigidBody(Collider _collider)
    {
        _Body = GetComponentInChildren<GameObject>();
        _collider.GetComponentInChildren<Collider>();

    }


}
