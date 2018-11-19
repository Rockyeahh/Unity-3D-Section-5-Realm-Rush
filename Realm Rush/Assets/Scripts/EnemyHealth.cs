using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    //[SerializeField] Collider collisionMesh; // Ricks idea that is currently pointless.

    [SerializeField] int enemyHealth = 10; // Rick calls it hitPoints.

	void Start () {
		
	}

    void OnParticleCollision(GameObject other)
    {
        print("Colliding");
        ProcessHits();
        if (enemyHealth <= 0) //Rick uses <= 1 whereas I was using < 1. I'll use ricks for now. Rick changed it to 0 but says < 1 would also work.
        {
            EnemyDies();
        }
    }

    private void ProcessHits()
    {
        print("hit taken");
        enemyHealth--;
        print("current health is " + enemyHealth);
    }

    private void EnemyDies()
    {
        print("Dies");
        Destroy(gameObject);
    }

}
