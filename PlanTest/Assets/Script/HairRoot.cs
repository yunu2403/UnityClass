using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairRoot : MonoBehaviour
{
    public GameObject hairPrefab;
    public int hairCount = 5;
    public float hairSize = 1;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 currentPos = transform.position;
        Rigidbody _rigidbody = GetComponentInChildren<Rigidbody>();
        var parent = new GameObject("hairs");
        for(int i = 0; i < hairCount; i++)
        {
            var hair = Instantiate(hairPrefab);
            hair.transform.SetParent(parent.transform);
            hair.transform.position = currentPos;
            hair.transform.localScale = new Vector3(1, 1, hairSize);
            var script = hair.GetComponent<Hair>();
            script.SetRigidBody(_rigidbody);
            currentPos += Vector3.forward * hairSize;
            _rigidbody = script.GetComponentInChildren<Rigidbody>();
        }
        
    }
}
