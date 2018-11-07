using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 20f;
    [SerializeField] ParticleSystem projectileParticle;

    void Update () {
        if (targetEnemy)
        {
        objectToPan.LookAt(targetEnemy);
        FireAtEnemy();
        } else
        {
            Shoot(false);
        }
	}

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position); // gameObjct.transform.position uses whatever gameObject this script is attached to.
        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        } else
        {
            Shoot(false);
        }
    }

    void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive; // Why don't we use Particlesystem.Play and Stop?
    }
}
