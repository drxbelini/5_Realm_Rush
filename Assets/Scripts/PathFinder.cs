using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startBlock, finishBlock;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter;
    List<Waypoint> path = new List<Waypoint>(); //todo become privite

    Vector2Int[] direction =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };


    public List<Waypoint> GetPath()
    {
        LoadBlocks();
        ChangeColor();
        BreadthFirstSearch();
        CreatePath();
        return path;
    }

    private void CreatePath()
    {
        path.Add(finishBlock);
        Waypoint previous = finishBlock.exploredFrom;

        while(previous != startBlock)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Add(startBlock);
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startBlock);
        
        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();        
            HaltEndFound();            
            ExploreNeighbours();
            searchCenter.isExplored = true;
        }

        print("Finishd path finding");
    }

    private void HaltEndFound()
    {
        if (searchCenter == finishBlock)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }

        foreach(Vector2Int directions in direction)
        {
            Vector2Int neighbourCoodinates = searchCenter.GetGridPos() + directions;
            if(grid.ContainsKey(neighbourCoodinates))
            {
                SeachingNewNeighbours(neighbourCoodinates);
            }
        }
    }

    private void SeachingNewNeighbours(Vector2Int neighbourCoodinates)
    {
       
        Waypoint neighbour = grid[neighbourCoodinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {
            //do nothing
        }
        else
        {
            neighbour.SetTopColor(Color.blue); // to do mvoe later
            queue.Enqueue(neighbour);            
            neighbour.exploredFrom = searchCenter;
        }
    }

    private void ChangeColor()
    {
        //todo maybe moving out 
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
