using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] EnemyMoviment Enemy;
    [SerializeField] Transform parentEmeny;
    [SerializeField] Text scoreText;
    [SerializeField] int enemyValue = 10;
    int scorePoint = 0;


    [Range (0.1f, 120f)]
    [SerializeField] float SpawnSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0";
        StartCoroutine(SpawningEnemies());
    }
   
    IEnumerator SpawningEnemies()
    {       
        while (true) //forever
        {
            Score();
            var newEnemy = Instantiate(Enemy, transform.position, Quaternion.identity);
            newEnemy.transform.parent = parentEmeny;            
            yield return new WaitForSeconds(SpawnSpeed);
        }
    }

    void Score()
    {
        scorePoint = scorePoint + enemyValue;
        scoreText.text = scorePoint.ToString();        
    }
}
