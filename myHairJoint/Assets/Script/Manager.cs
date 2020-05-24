using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    public static HairGeneration currentHairGeneration;
    public Button button;


    private LayerMask _layerMaskRoot;


    public void OnClickMakeRoot()
    {
        if (MouseCapture.Instance.selectArea.activeSelf == false)
            return;

        var obj = Instantiate(MouseCapture.Instance.hairGenrationPrefab);
        obj.transform.position = MouseCapture.Instance.selectArea.transform.position;
        obj.transform.rotation = MouseCapture.Instance.selectArea.transform.rotation;
        MouseCapture.Instance.selectArea.SetActive(false);

        var script = obj.GetComponentInChildren<HairStartCube>();
        script.SyncPosition();

        HairGeneration.SelectItem(obj.GetComponent<HairGeneration>());
    }

    public void OnClickNextItem()
    {
        var index = HairGeneration._List.IndexOf(currentHairGeneration);

        index++;
        if (index > HairGeneration._List.Count - 1)
        {
            index = 0;
        }

        HairGeneration.SelectItem(HairGeneration._List[index]);

    }

    public void OnClickMakeHair()
    {
        if (currentHairGeneration != null)
        {
            currentHairGeneration.MakeHair();
        }
    }

    public void OnClickMoveHair()
    {
        if (currentHairGeneration != null)
        {
            currentHairGeneration.SetLastHairMoveable(true);
        }
    }

    public void OnClickStopHair()
    {
        if (currentHairGeneration != null)
        {
            currentHairGeneration.SetLastHairMoveable(false);
        }
    }

    public void OnClickDeleteHair()
    {
        if (currentHairGeneration != null)
        {
            currentHairGeneration.DeleteHair();
        }
    }


}

















































