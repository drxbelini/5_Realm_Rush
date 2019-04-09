using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    [SerializeField] Waypoint startBlock, finishBlock;



    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ChangeColor();
    }

    private void ChangeColor()
    {
        startBlock.SetTopColor(Color.green);
        finishBlock.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType <Waypoint>();
        

        foreach (Waypoint waypoint in waypoints)
        {
            var wayPointPos = waypoint.GetGridPos();            
            if (grid.ContainsKey(wayPointPos))
            {
                Debug.LogWarning("Skiping overlaping block" + wayPointPos);
            }
            else
            {
                grid.Add(wayPointPos, waypoint);              
            }            
        }
        
    }
}
