using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairGeneration : MonoBehaviour
{
    public static List<HairGeneration> _List = new List<HairGeneration>();
    public static List<Hair> _LastHairList = new List<Hair>();

    //public static List<hair>

    public GameObject hairRoot;
    public GameObject hairPrefab;
    public int hairCount = 5;
    public float hairSize = 1;

    [HideInInspector]
    public Hair lastHair;
    public Renderer targetRender;
    private bool isMade = false;


    public static void SelectItem(HairGeneration target)
    {
        if (Manager.currentHairGeneration != null)
        {
            Manager.currentHairGeneration.targetRender.material.color = Color.white;
        }

        Manager.currentHairGeneration = target;
        Manager.currentHairGeneration.targetRender.material.color = Color.red;
    }

    public static void SetAllLastHairMoveable(bool isKinematic)
    {
        foreach (var hair in _LastHairList)
        {
            var rigdBody = hair.joint.GetComponent<Rigidbody>();
            rigdBody.isKinematic = (isKinematic == false); // !isKinematic
        }
    }


    public void SetLastHairMoveable(bool isKinematic)
    {
        var rigdBody = lastHair.joint.GetComponent<Rigidbody>();
        rigdBody.isKinematic = (isKinematic == false); // !isKinematic
    }

    private void Awake()
    {
        _List.Add(this);
        SelectItem(this);
    }

    public void MakeHair()
    {
        if (isMade == true)
            return;

        Vector3 currentPos = hairRoot.transform.position;
        Rigidbody _rigidbody = GetComponentInChildren<Rigidbody>();
        var parent = new GameObject("hairGroup");
        for (int i = 0; i < hairCount; i++)
        {
            var hair = Instantiate(hairPrefab);
            hair.transform.position = currentPos;
            hair.transform.SetParent(parent.transform);
            hair.transform.localRotation = parent.transform.localRotation;
            hair.transform.localScale = new Vector3(1, 1, hairSize); /*new Vector3(0.5f, 1, hairSize);*/
            var script = hair.GetComponent<Hair>();
            script.SetRigidBody(_rigidbody);
            currentPos += Vector3.forward * hairSize;
            _rigidbody = script.GetComponentInChildren<Rigidbody>();

            if (i == hairCount - 1)
            {
                _LastHairList.Add(script);
                lastHair = script;
            }
        }

        isMade = true;
    }

}




