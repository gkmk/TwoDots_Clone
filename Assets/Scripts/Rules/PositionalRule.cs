using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionalRule : IRule
{
    public bool Validate(GameObject current, GameObject previous)
    {
        Vector3 lastPosition = previous.transform.position;
        //  check for diagonal, only allow cross move
        //if (lastPosition.x != current.transform.position.x && lastPosition.y != current.transform.position.y)
        //{
        //    Debug.Log("Validation: fails at position");
        //    return false;
        //}

        //  check for distance, cant go over 1
        if (Vector3.Distance(lastPosition, current.transform.position) > 1.25)
        {
            Debug.Log("Validation: fails at distance " + Vector3.Distance(lastPosition, current.transform.position));
            return false;
        }

        //  Validation pass
        return true;
    }
}
