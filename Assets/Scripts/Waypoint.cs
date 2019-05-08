using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceble = true;
    [SerializeField] Tower towerPreefab;
   
    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int (
              Mathf.RoundToInt(transform.position.x / gridSize),
              Mathf.RoundToInt(transform.position.z / gridSize)
              );
    }

    void OnMouseOver()
    {    
        if (Input.GetKeyDown(KeyCode.Mouse0) && isPlaceble)
        {
            Debug.Log("Mouse is over GameObject:" + gameObject.name);                      
            Instantiate(towerPreefab, transform.position, Quaternion.identity);
            isPlaceble = false;
        }        
    }
}
