using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairGeneration : MonoBehaviour
{
    public static List<HairGeneration> _List = new List<HairGeneration>();
    public static List<Hair> _LastHairList = new List<Hair>();

    //public static List<hair>

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
            if(Manager.currentHairGeneration.isMade == true)
                Manager.currentHairGeneration.targetRender.material.color = new Color(1,1,1,0);
            else
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

        Rigidbody _rigidbody = GetComponentInChildren<Rigidbody>();

        for (int i = 0; i < hairCount; i++)
        {
            var hair = Instantiate(hairPrefab, transform);
            hair.transform.localPosition = Vector3.zero;
            hair.transform.localScale = new Vector3(hair.transform.localScale.x /transform.localScale.x, hair.transform.localScale.y / transform.localScale.y, 1 / transform.localScale.z * hairSize); /*new Vector3(0.5f, 1, hairSize);*/
            var script = hair.GetComponent<Hair>();

            if (i == 0)
            {
                script.joint.useLimits = false;
            }


            hair.transform.Translate(Vector3.forward * i * hairSize);


            script.SetRigidBody(_rigidbody);
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




