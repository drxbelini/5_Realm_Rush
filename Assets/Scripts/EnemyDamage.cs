using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    
    [SerializeField] ParticleSystem hitFX;
    [SerializeField] ParticleSystem deathFX;
    [SerializeField] int hits = 30;
    [SerializeField] int damageHits = 3;
    
    void OnParticleCollision(GameObject other)
    {        
        if (hits >= 0)
        {
            hitFX.Play();
            hits = hits - damageHits;
        }
        else
        {
            var playFX = Instantiate(deathFX, transform.position, Quaternion.identity);
            float destroyDelay = playFX.main.duration;
            Destroy(playFX.gameObject,destroyDelay);              
            playFX.Play();
            Destroy(gameObject);
        }
    }
}
