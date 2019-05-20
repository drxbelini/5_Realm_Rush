using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHelth : MonoBehaviour
{
    [SerializeField] int lifePoints = 50000;
    [SerializeField] int damagePoints = 1000;
    [SerializeField] Text helthText;
    [SerializeField] AudioClip damageSFX;
    

    private void Start()
    {
        helthText.text = lifePoints.ToString();
    }
    public void HelthDecreacer()
    {
        GetComponent<AudioSource>().PlayOneShot(damageSFX);
        lifePoints = lifePoints - damagePoints;
        helthText.text = lifePoints.ToString();

        if (lifePoints <= 0)
        {
            deathSequence();
        }
    }

    private void deathSequence()
    {
        helthText.text = "Base destroyed";
        print("your death");
        Destroy(gameObject);
    }
}
