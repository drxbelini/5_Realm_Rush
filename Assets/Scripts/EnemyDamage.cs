using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] ParticleSystem hitFX;
    [SerializeField] int hits = 30;

    void OnParticleCollision(GameObject other)
    {
        hitFX.Play();
        if(hits > 1)
        {
            hits--;
        }

        else
        {         
            Destroy(gameObject);
        }
    }
}
