using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairGeneration : MonoBehaviour
{
    public static List<HairGeneration> _List = new List<HairGeneration>();
    //public static List<HairRoot> _LastHairList = new List<HairRoot>();

    //public static List<hair>

    public GameObject hairPrefab;
    public int hairCount = 5;
    public float hairSize = 1;

    [HideInInspector]
    public HairRoot lastHair;
    public Renderer targetRender;
    private bool isMade = false;


    public static void SelectItem(HairGeneration target)
    {
        if (Manager.currentHairGeneration != null)
        {
            if (Manager.currentHairGeneration.isMade == true)
                Manager.currentHairGeneration.targetRender.material.color = new Color(1, 1, 1, 0);
            else
                Manager.currentHairGeneration.targetRender.material.color = Color.white;
        }

        Manager.currentHairGeneration = target;
        Manager.currentHairGeneration.targetRender.material.color = Color.red;
    }

    //public static void SetAllLastHairMoveable(bool isKinematic)
    //{
    //    foreach (var hair in _LastHairList)
    //    {
    //        var rigdBody = hair.GetComponent<Rigidbody>();
    //        rigdBody.isKinematic = (isKinematic == false); // !isKinematic
    //    }
    //}


    //public void SetLastHairMoveable(bool isKinematic)
    //{
    //    var rigdBody = lastHair.GetComponent<Rigidbody>();
    //    rigdBody.isKinematic = (isKinematic == false); // !isKinematic
    //}

    private void Awake()
    {
        //_List.Add(this);
        SelectItem(this);
    }

    public void MakeHair()
    {
        if (isMade == true)
            return;

        var hair = Instantiate(hairPrefab, transform);
        hair.transform.localPosition = Vector3.zero;
        var script = hair.GetComponent<HairRoot>();
        script.MakeHair();
        isMade = true;
    }

    public void DeleteHair()    //(Left)Alt+왼쪽마우스버튼 클릭 시, 선택된 헤어 삭제
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt) && Input.GetMouseButtonDown(0))
        {
            Ray delRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit delHit;
            bool didHit = Physics.Raycast(delRay, out delHit, 500.0f);
            if (didHit)
            {
                Destroy(delHit.collider.gameObject);
            }
        }
    }

}




