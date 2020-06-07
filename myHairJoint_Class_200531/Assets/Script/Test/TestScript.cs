using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TestScript : MonoBehaviour
{
    public GameObject line;
    public GameObject pointPrefab;
    LineRenderer lineRenderer;
    GameObject[] childs;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        childs = new GameObject[lineRenderer.positionCount];
        var Pos = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(Pos);

        Debug.Log(Pos.Length);
        for(int i = 0; i < Pos.Length; i++)
        {
            childs[i] = Instantiate(pointPrefab, transform);
            childs[i].transform.position = Pos[i];
        }
    }
    private void Update()
    {

    }
}
