using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;    
    [SerializeField] ParticleSystem bullets;
    [SerializeField] float atackRange = 10f;

    Transform targetEnemy;

    void Update()
    {
        SetTargetEnemy();

        if (targetEnemy)
        {
         objectToPan.LookAt(targetEnemy);
         FireEnemy();
        }

        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemys = FindObjectsOfType<EnemyDamage>();
        if(sceneEnemys.Length == 0) { return; }

        Transform closestEnemy = sceneEnemys[0].transform;

        foreach(EnemyDamage testEnemy in sceneEnemys)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }
        targetEnemy = closestEnemy;
    
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var distToA = Vector3.Distance(transform.position, transformA.transform.position);
        var distToB = Vector3.Distance(transform.position, transformB.transform.position);

        if(distToA < distToB)
        {
            return transformA;
        }
        return transformB;

    }

    private void FireEnemy()
    {
       float distanceToEnemy =  Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);


        if(distanceToEnemy <= atackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    
    }

    void Shoot(bool isActive)
    {
        var emissionModule = bullets.emission;
        emissionModule.enabled = isActive;
    }

}
