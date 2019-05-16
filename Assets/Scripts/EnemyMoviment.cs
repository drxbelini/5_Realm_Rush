using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoviment : MonoBehaviour
{
    [SerializeField] float gameSpeed = .5f;
    [SerializeField] ParticleSystem explosionDamage;
    PlayerHelth playerHelth;

    // Start is called before the first frame update
    void Start()
    {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint>path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(gameSpeed);
        }
       // playerHelth.HelthDecreacer();
        damageOnBaseFX();
    }

    private void damageOnBaseFX()
    {
        var newExplosion = Instantiate<ParticleSystem>(explosionDamage, transform.position, Quaternion.identity);
        newExplosion.Play();
        Destroy(newExplosion.gameObject, 5f);
        Destroy(gameObject);
    }
}
