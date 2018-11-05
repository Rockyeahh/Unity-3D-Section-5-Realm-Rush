using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    //[SerializeField] Collider collisionMesh; // Ricks idea that is currently pointless.

    // Enemyhealth
    [SerializeField] int enemyHealth = 10;

	void Start () {
		
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
