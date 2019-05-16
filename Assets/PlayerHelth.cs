using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHelth : MonoBehaviour
{
    [SerializeField] int lifePoints = 5;

   public void HelthDecreacer()
    {
        lifePoints--;

        if (lifePoints <= 0)
        {
            deathSequence();
        }
    }

    private static void deathSequence()
    {
        print("your death");
    }
}
