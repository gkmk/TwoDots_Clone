using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotDrag : MonoBehaviour
{
    //  Fire event when dot is selected
    public static event Action<GameObject> onDotSelected = delegate { };
    public void DotSelectedTrigger()
    {
        onDotSelected(gameObject);
    }

    //  Fire event when input is complete
    public static event Action onSelectionComplete = delegate { };
    public void SelectionComplete()
    {
        onSelectionComplete();
    }

    //  Select dot on drag
    private void OnMouseEnter()
    {
        Debug.Log("ENTER");
        if (Input.GetMouseButton(0))
        {
            DotSelectedTrigger();
        }
    }

    //  select dot on first input
    private void OnMouseDown()
    {
        Debug.Log("KLIK");
        if (Input.GetMouseButton(0))
        {
            DotSelectedTrigger();
        }
    }

    //  complete selection
    private void OnMouseUp()
    {
        Debug.Log("should stop");
        SelectionComplete();
    }
}
