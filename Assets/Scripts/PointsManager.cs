using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    Dictionary<PointType, int> levelPoints;

    public Text[] uiPoints;

    static int gamePoints;

    private PointsManager() { }
    static PointsManager _instance;

    public static PointsManager GetInstance()
    {
        if (_instance == null) _instance = new PointsManager();

        return _instance;
    }

    private void Start()
    {
        _instance = this;
        levelPoints = new Dictionary<PointType, int>();
    }

    public void UpdatePoints(PointType pointType, int points)
    {
        if (levelPoints.ContainsKey(pointType))
        {
            levelPoints[pointType] += points;
        } else
        {
            levelPoints.Add(pointType, points);
        }
        if (pointType == PointType.Blue)
        {
            uiPoints[0].text = levelPoints[pointType].ToString();
        }
        if (pointType == PointType.Red)
        {
            uiPoints[1].text = levelPoints[pointType].ToString();
        }
        if (pointType == PointType.Yellow)
        {
            uiPoints[2].text = levelPoints[pointType].ToString();
        }
    }
}
