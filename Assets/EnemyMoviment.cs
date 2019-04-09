using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoviment : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;

    // Start is called before the first frame update
    void Start()
    {
        print("Starting patrol");
        StartCoroutine(FollowPath());    
    }

    IEnumerator FollowPath()
    {   
        foreach(Waypoint waypoint in path)
        {
            print("visiting block" + waypoint);
            Vector3 pos = new Vector3(waypoint.transform.position.x, waypoint.transform.position.y + 5f, waypoint.transform.position.z);
            transform.position = pos;

            yield return new WaitForSeconds(1f);
        }
        print("ending patrol");        
    }

}
