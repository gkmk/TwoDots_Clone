using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject dot;

    public DotType[] dotTypes;

    protected GameObject[,] boardDots;

    public int dotsWidth;
    public int dotsHeight;

    // Start is called before the first frame update
    void Start()
    {
        boardDots = new GameObject[dotsHeight, dotsWidth];
        for (int i = 0; i < dotsHeight; i++)
        {
            for (int l = 0; l < dotsWidth; l++)
            {
                GameObject newDot = Instantiate(dot, new Vector3(dotsWidth / -2 + l + .5f, dotsHeight / 2 - i - .5f, 0), Quaternion.identity);
                InitializeDot dotInitializer = newDot.GetComponent<InitializeDot>();
                dotInitializer.dotType = dotTypes[Random.Range(0, dotTypes.Length)];
                dotInitializer.Refresh();
                boardDots[i, l] = newDot;
            }
        }
    }
   
}
