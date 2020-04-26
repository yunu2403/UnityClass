using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    public GameObject hairRootPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 currentPos = transform.position;
        for(int i = 0; i< 40; i ++)
        {
            var root = Instantiate(hairRootPrefab);
            root.transform.position = currentPos;
            currentPos += Vector3.right * .1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
