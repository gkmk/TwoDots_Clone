using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRule : IRule
{
    public bool Validate(GameObject current, GameObject previous)
    {
        InitializeDot currentDotType = current.GetComponent<InitializeDot>();
        InitializeDot previousDotType = previous.GetComponent<InitializeDot>();

        if (currentDotType.dotType.color != previousDotType.dotType.color)
        {
            Debug.Log("Validation: fails at color");
            return false;
        }
        return true;
    }
}
