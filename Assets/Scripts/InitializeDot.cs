using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeDot : MonoBehaviour
{
    public DotType dotType;

    // Start is called before the first frame update
    void Start()
    {
        ApplyDotType();
    }

    void ApplyDotType()
    {
        transform.GetComponent<SpriteRenderer>().color = dotType.color;
    }

    public void Refresh()
    {
        ApplyDotType();
    }

}
