using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    //[SerializeField] Collider collisionMesh; // Ricks idea that is currently pointless.

    [SerializeField] int enemyHealth = 10; // Rick calls it hitPoints.
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;

    void OnParticleCollision(GameObject other)
    {
        ProcessHits();
        if (enemyHealth <= 0) //Rick uses <= 1 whereas I was using < 1. I'll use ricks for now. Rick changed it to 0 but says < 1 would also work.
        {
            EnemyDies();
        }
    }

    private void ProcessHits()
    {
        enemyHealth--;
        hitParticlePrefab.Play();
    }

    private void EnemyDies()
    {
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);

        Destroy(gameObject); // destroy enemy
    }

}
