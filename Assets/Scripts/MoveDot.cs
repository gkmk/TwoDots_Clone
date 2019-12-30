using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDot : MonoBehaviour
{
    public float speed = .5f;

    Vector3 nextPostion;

    private void Awake()
    {
        nextPostion = transform.position;
    }

    public void MoveDown( )
    {
        nextPostion += Vector3.down;
    }

    public void ResetTo(Vector3 newPosition)
    {
        transform.position = nextPostion = newPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, nextPostion) > 0.01)
        {
            transform.position = Vector3.Lerp(transform.position, nextPostion, Time.fixedDeltaTime * speed);
        }
    }
}
