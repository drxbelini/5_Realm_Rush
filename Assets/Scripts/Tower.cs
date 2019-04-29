using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targerEnemy;
    [SerializeField] ParticleSystem bullets;
    [SerializeField] float atackRange = 10f;


    void Update()
    {
        if (targerEnemy)
        {
         objectToPan.LookAt(targerEnemy);
         FireEnemy();
        }

        else
        {
            Shoot(false);
        }
    }

    private void FireEnemy()
    {
       float distanceToEnemy =  Vector3.Distance(targerEnemy.transform.position, gameObject.transform.position);


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
