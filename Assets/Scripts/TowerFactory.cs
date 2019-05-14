using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int toweLimit = 5;
    [SerializeField] Tower towerPreefab;
    [SerializeField] Transform towerParentTransform;

    Queue<Tower> queueOfTowers = new Queue<Tower>();

    public void AddTower(Waypoint waypointBase)
    {
        int numOfTowers = queueOfTowers.Count;

        if (numOfTowers < toweLimit)
        {
            InstancietNewTower(waypointBase);            
        }
        else
        {
            MoveTower(waypointBase);            
        }
    }

    private void InstancietNewTower(Waypoint waypointBase)
    {
        var newTower = Instantiate(towerPreefab, waypointBase.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParentTransform;
        waypointBase.isPlaceble = false;
        newTower.baseWaypoint = waypointBase;

        queueOfTowers.Enqueue (newTower);        
    }

    private void MoveTower(Waypoint newTowerBase)
    {
        var olderTower = queueOfTowers.Dequeue();

        olderTower.baseWaypoint.isPlaceble = true;
        newTowerBase.isPlaceble = false;

        olderTower.baseWaypoint = newTowerBase;

        olderTower.transform.position = newTowerBase.transform.position;
        
        queueOfTowers.Enqueue(olderTower);       
    }  
}
