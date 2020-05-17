using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairRootMaker : MonoBehaviour
{
    public GameObject hairRootPrefab;

    // Start is called before the first frame update
    void RootGeneration()
    {
        Vector3 currentPos = transform.position;

        var root = Instantiate(hairRootPrefab);
        root.transform.position = currentPos;
        currentPos += Vector3.right * .3f;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
