using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject dot;
    public DotType[] dotTypes;
    public int levelGoal = 10;
    public Vector2 boardSize;

    public static LevelGenerator _instance;

    protected static GameObject[,] boardDots;

    private LevelGenerator() { }
    public static LevelGenerator GetInstance()
    {
        return _instance;
    }

    private void Awake()
    {
        _instance = this;
    }

    public void UpdatePositions(PointType removeAllFromType = PointType.None)
    {
        int points = 0;
        PointType pt = removeAllFromType;
        for (int i = 0; i < boardSize.y; i++)
        {
            for (int l = 0; l < boardSize.x; l++)
            {
                if (removeAllFromType != PointType.None)
                {
                    if (boardDots[i, l].GetComponent<InitializeDot>().dotType.pointType == removeAllFromType)
                    {
                        ProcessDot(i, l);
                        points++;
                    }
                }
                else if (!boardDots[i,l].activeSelf)
                {
                    pt = boardDots[i, l].GetComponent<InitializeDot>().dotType.pointType;
                    ProcessDot(i, l);
                    points++;
                }
            }
        }
        if (pt != PointType.None) PointsManager.GetInstance().UpdatePoints(pt, points, levelGoal);
    }

    //  Process dot for removal
    private void ProcessDot(int i, int l)
    {
        //  save the found dot
        GameObject tempDot = boardDots[i, l];

        //  re-order the matrix and move down the dots from above
        for (int t = 0; t < i; t++)
        {
            boardDots[i - t, l] = boardDots[i - t - 1, l];
            boardDots[i - t, l].GetComponent<MoveDot>().MoveDown();
        }

        //  update old dots position
        tempDot.GetComponent<MoveDot>().ResetTo(tempDot.transform.position + Vector3.up * (i + 1));

        //  refresh the found dot with new properties
        InitializeDot dotInitializer = tempDot.GetComponent<InitializeDot>();
        dotInitializer.dotType = dotTypes[UnityEngine.Random.Range(0, dotTypes.Length)];
        dotInitializer.Refresh();

        //  reactivate and move to top
        tempDot.SetActive(true);
        tempDot.GetComponent<MoveDot>().MoveDown();

        //  re-asign the old dot to fresh new start
        boardDots[0, l] = tempDot;
    }

    // Start is called before the first frame update
    void Start()
    {
        boardDots = new GameObject[(int)boardSize.y, (int)boardSize.x];
        for (int i = 0; i < boardSize.y; i++)
        {
            for (int l = 0; l < boardSize.x; l++)
            {
                GameObject newDot = Instantiate(dot, new Vector3(boardSize.x / -2 + l + .5f, boardSize.y / 2 - i - .5f, 0), Quaternion.identity);
                newDot.name = "x" + l + "y" + i;
                InitializeDot dotInitializer = newDot.GetComponent<InitializeDot>();
                dotInitializer.dotType = dotTypes[UnityEngine.Random.Range(0, dotTypes.Length)];
                dotInitializer.Refresh();
                boardDots[i, l] = newDot;
            }
        }
    }
   
}
