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

    public void UpdatePoints(PointType pointType, int points, int levelGoal)
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
            if (levelPoints[pointType] >= levelGoal) uiPoints[0].text = "Done";
            else uiPoints[0].text = levelPoints[pointType].ToString() + "/" + levelGoal.ToString();
        }
        if (pointType == PointType.Red)
        {
            if (levelPoints[pointType] >= levelGoal) uiPoints[1].text = "Done";
            else uiPoints[1].text = levelPoints[pointType].ToString() + "/" + levelGoal.ToString();
        }
        if (pointType == PointType.Yellow)
        {
            if (levelPoints[pointType] >= levelGoal) uiPoints[2].text = "Done";
            else uiPoints[2].text = levelPoints[pointType].ToString() + "/" + levelGoal.ToString();
        }
    }
}
