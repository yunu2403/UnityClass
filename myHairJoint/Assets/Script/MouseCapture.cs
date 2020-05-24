using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.WSA;

public class MouseCapture : MonoBehaviour
{
    public static MouseCapture Instance
    {
        get
        {
            if (_Instance == null)
                _Instance = FindObjectOfType<MouseCapture>();
            return _Instance;
        }
    }
    private static MouseCapture _Instance;


    public Camera mainCam;
    public GameObject selectArea;
    public GameObject hairGenrationPrefab;

    private Vector2 mouseStartPosRotation;

    public bool HandleMiddleClick = false;
    public string OnMiddleClickName = "OnMiddleClick";
    public LayerMask layerMask;

    //[HideInInspector]


    // Update is called once per frame
    void Update()
    {
        GameObject clickedGameObject = null;
        bool clickedGmObjAcquired = false;


        #region 카메라 회전 이동 및 줌 인/아웃
        if (Input.GetMouseButtonDown(1))
        {
            mouseStartPosRotation = Input.mousePosition;
        }

        if (Input.GetMouseButton(1)) // 드레그
        {
            Vector2 delta = (Vector2)Input.mousePosition - mouseStartPosRotation;
            if (delta != Vector2.zero)
            {
                delta = new Vector2(-delta.y, delta.x);
                mainCam.transform.Rotate(delta / 25f);
                mainCam.transform.rotation = Quaternion.Euler(mainCam.transform.rotation.eulerAngles.x, mainCam.transform.rotation.eulerAngles.y, 0);
            }
            mouseStartPosRotation = Input.mousePosition;
        }

        if (Input.mouseScrollDelta != Vector2.zero) /// 줌 인/아웃
        {

            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

            mainCam.transform.position += ray.direction * Input.mouseScrollDelta.y * 10;

        }

        #endregion


        #region 마우스 클릭 시 HairRoot 생성과 이동 및 생성 방향으로 로테이션

        if (Input.GetMouseButton(0)) /// 마우스 클릭 시 HairRoot 생성과 이동
        {

            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            RaycastHit hit;
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                if (objectHit.gameObject.layer == LayerMask.NameToLayer("model"))
                {
                    //var obj = Instantiate(hairGenrationPrefab);
                    selectArea.SetActive(true);
                    selectArea.transform.position = hit.point;
                }
                else if (objectHit.gameObject.layer == LayerMask.NameToLayer("hairRoot"))
                {
                    HairGeneration.SelectItem(objectHit.GetComponentInParent<HairGeneration>());
                }
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            selectArea.transform.Rotate(Vector3.right/6f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            selectArea.transform.Rotate(Vector3.left/6f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            selectArea.transform.Rotate(Vector3.up/6f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            selectArea.transform.Rotate(Vector3.down/6f);
        }

        #endregion



        //////////마우스 가운데 버튼 클릭 드래그 시, 오브젝트 상하좌우 이동

        #region 마우스 가운데 버튼 클릭 드래그 시, 오브젝트 상하좌우 이동

        if (HandleMiddleClick && Input.GetMouseButtonDown(2))
        {
            if (!clickedGmObjAcquired)
            {
                clickedGameObject = GetClickedGameObject();
                clickedGmObjAcquired = true;
            }
            if (clickedGameObject != null)
                clickedGameObject.SendMessage(OnMiddleClickName, null, SendMessageOptions.DontRequireReceiver);
        }


        GameObject GetClickedGameObject()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
                return hit.transform.gameObject;
            else
                return null;
        }

        #endregion

    }


}







