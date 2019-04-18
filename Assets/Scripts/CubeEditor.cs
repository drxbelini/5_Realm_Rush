using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode] //For make the script work in Edit mode on unity. 
[SelectionBase] //For the selection on the game object in the editor prioritise the father of hierarchy when is selected on scene screen.
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
        string cubeLable = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = cubeLable;
        gameObject.name = cubeLable;
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();

               transform.position = new Vector3(
                   waypoint.GetGridPos().x * gridSize, 
                   0f, 
                   waypoint.GetGridPos().y * gridSize
                   );
    }
}
