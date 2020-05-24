using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelScript : MonoBehaviour
{
    public static ModelScript Model
    {
        get
        {
            if (_model == null)
                _model = FindObjectOfType<ModelScript>();
            return _model;
        }
    }
    private static ModelScript _model;



}
