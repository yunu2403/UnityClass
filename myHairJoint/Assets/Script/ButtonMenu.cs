using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMenu : MonoBehaviour
{
    public GameObject hairPrefab;
    public int[] hairList;  

    public void IsKinematicChange()
    {
        Rigidbody _rigidbody = GetComponentInChildren<Rigidbody>();
        var parent = new GameObject("hairs");
        var hair = Instantiate(hairPrefab);

        var script = hair.GetComponent<Hair>();
        script.SetRigidBody(_rigidbody);

        foreach (var item in hairList)
        {
            if (hairList.IsReadOnly)
            {
                var generation = hairPrefab.GetComponent<HairGeneration>();


                //hairList = _rigidbody.r
                //last= hair.GetComponent<Hair>();
            }

        }

        _rigidbody.isKinematic = false;

    }

}

















































