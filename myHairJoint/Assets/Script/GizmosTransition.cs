using System.Collections;
using System.Collections.Generic;
//using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class GizmosTransition : MonoBehaviour
{
    private Vector3 mOffset;

    private float mZCoord;

    //private void OnDrawGizmos()
    //{
    //    Gizmos.matrix = this.transform.localToWorldMatrix;
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawCube(Vector3.zero, Vector3.one);
    //}

       private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        //Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        //pixel coordinates (x,y)
        Vector3 mousePoint = Input.mousePosition;

        //z coordinate of game object on screen
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }

}