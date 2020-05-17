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
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit _raycastHit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _raycastHit,_layerMaskRoot))
            {
                _raycastHit.collider.GetComponentInParent<HairGeneration>().SelectItem();
            }
        }        
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
}

















































