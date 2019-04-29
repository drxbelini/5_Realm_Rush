using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] EnemyMoviment Enemy;
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

            Instantiate(Enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(3f);

        }
    }
}
