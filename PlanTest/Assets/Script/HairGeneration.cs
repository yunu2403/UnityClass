using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.WSA.Input;

public class HairGeneration : MonoBehaviour
{
    public GameObject start;
    public Rigidbody _rigidbody;
    public int hairCount = 1;


    void Start()
    {
        GameObject currentobj = start;
        Rigidbody currentRigidbody = start.GetComponent<Rigidbody>();
        Vector3 target = new Vector3(0, 0, -5f);

        for (int i = 0; i < hairCount; i++)
        {
            var obj = Instantiate(currentobj);
            obj.transform.position += Vector3.MoveTowards(transform.position, target, 1f);
            var script = obj.AddComponent<CharacterJoint>();
            script.connectedBody = currentRigidbody;
            start = obj;
            currentRigidbody = obj.GetComponent<Rigidbody>();
        }
    }
}       
          
    

