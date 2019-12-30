using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotChecker : MonoBehaviour
{
    List<GameObject> selectedDots;
    public LineRenderer connectedLines;



    private void Awake()
    {
        selectedDots = new List<GameObject>();

        DotDrag.onDotSelected += AddDot;
        DotDrag.onSelectionComplete += ProcessSelection;
    }

    private void ProcessSelection()
    {
        if (selectedDots.Count > 1) 
        foreach (GameObject item in selectedDots)
        {
            item.SetActive(false);
            //Destroy(item);
        }
        
        LevelGenerator.UpdatePositions();
        selectedDots.Clear();
        connectedLines.positionCount = 0;
    }

    void AddDotAtPostion(GameObject dot)
    {
        selectedDots.Add(dot);
        UpdateLineRenderer();
    }

    //  add line to the selected dot
    void AddDot(GameObject dot)
    {
        connectedLines.loop = false;
        if (!selectedDots.Contains(dot))
        {
            if (selectedDots.Count < 1)
            {
                //  first dot is selected
                AddDotAtPostion(dot);
            }
            else
            {
                //  consecutive dots apply logic if need to be selected
                if (ProcessSelectionRules(dot))
                    AddDotAtPostion(dot);
            }
        }
        else
        {
            if (selectedDots[0] == dot && selectedDots.Count>2 && ProcessSelectionRules(dot))
            {
                //  first dot is selected, close the loop
                connectedLines.loop = true;
            }
            else
            {
                //  player has selected previous dot, see if it wants to go back
                RemoveDot(dot);
            }
        }
    }

    /**
     * Check if the dot can be selected
     */
    bool ProcessSelectionRules(GameObject dot)
    {
        foreach (RulesFactory.AvailableRules rule in Enum.GetValues(typeof(RulesFactory.AvailableRules)))
        {
            IRule newRule = new RulesFactory().Create(rule);
            if (!newRule.Validate(dot, selectedDots[selectedDots.Count-1]))
                return false;
        }

        return true;
    }
    
    //  player moves back remove, last dot
    void RemoveDot(GameObject dot)
    {
        if (selectedDots[selectedDots.Count-2] == dot)
        {
            Debug.Log("remove position" + dot);
            selectedDots.RemoveAt(selectedDots.Count - 1);
            UpdateLineRenderer();
        }
    }

    void UpdateLineRenderer()
    {
        connectedLines.positionCount = selectedDots.Count;
        int i = 0;
        foreach (GameObject dot in selectedDots)
        {
            connectedLines.SetPosition(i, dot.transform.position);
            i++;
        }
    }
    
}
