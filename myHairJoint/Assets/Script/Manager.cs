using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    public static HairGeneration currentHairGeneration;

    public void OnClickMakeHair()
    {
        HairGeneration.MakeAllHair();

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
        //HairGeneration.SetAllLastHairMoveable(false);
        if (currentHairGeneration != null)
        {
            currentHairGeneration.SetLastHairMoveable(false);
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
}

















































