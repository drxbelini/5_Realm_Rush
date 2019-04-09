using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]


public class CubeEditor : MonoBehaviour
{    

    Waypoint waypoint;                           
    
    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }
    
    // Update is called once per frame
    void Update()
    {
        UpdatLable();
        SnapToGrid();     
    }

    private void UpdatLable()
    {
        int gridSize = waypoint.GetGridSize();

        string cubeLable = waypoint.GetGridPos().x / gridSize + "," + waypoint.GetGridPos().y / gridSize;
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = cubeLable;
        gameObject.name = cubeLable;
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();

               transform.position = new Vector3(
                   waypoint.GetGridPos().x, 
                   0f, 
                   waypoint.GetGridPos().y
                   );
    }
}
