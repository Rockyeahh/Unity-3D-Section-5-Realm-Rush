using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    // Enemyhealth
    [SerializeField] int enemyHealth = 10;

	void Start () {
		
	}
	
	void Update () {
        // print Enemyhealth.
        print(enemyHealth);
	}

    // particle collision method.
    void OnParticleCollision(GameObject other)
    {
        print("Colliding");
        ProcessHits();
        if (enemyHealth < 1)
        {
            EnemyDies();
        }
    }

    private void ProcessHits()
    {
        print("hit taken");
        enemyHealth--;
    }

    // Death method.
    private void EnemyDies()
    {
        print("Dies");
        Destroy(gameObject);
    }

}
