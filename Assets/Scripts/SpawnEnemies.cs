using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] EnemyMoviment Enemy;
    [SerializeField] Transform parentEmeny;

    [Range (0.1f, 120f)]
    [SerializeField] float SpawnSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawningEnemies());
    }
   
    IEnumerator SpawningEnemies()
    {
        while (true) //forever
        {
            var newEnemy = Instantiate(Enemy, transform.position, Quaternion.identity);
            newEnemy.transform.parent = parentEmeny;
            yield return new WaitForSeconds(3f);            
        }
    }
}
