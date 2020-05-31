using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HairStartCube : MonoBehaviour
{
    bool isSync = false;
    Vector3 offset;

    public void SyncPosition()
    {
        isSync = true;
        offset = (transform.position - ModelScript.Model.transform.position);
    }

    private void Update()
    {
        if(isSync)
        {
            transform.position = ModelScript.Model.transform.position + offset;
        }
    }


}
