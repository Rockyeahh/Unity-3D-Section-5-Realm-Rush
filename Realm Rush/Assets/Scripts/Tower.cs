using System;
using UnityEngine;

public class Tower : MonoBehaviour {

    // Parameters of each tower.
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 20f;
    [SerializeField] ParticleSystem projectileParticle;

    // State of each tower.
    Transform targetEnemy;

    void Update () {
        SetTargetEnemy();
        if (targetEnemy)
        {
        objectToPan.LookAt(targetEnemy);
        FireAtEnemy();
        } else
        {
            Shoot(false);
        }
	}

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyHealth>();
        if (sceneEnemies.Length == 0)
        {
            return;
        }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyHealth testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform); // testEnemies are basically the sceneEnemies, it just needs a name here in order to find the transfom C#.
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var distToA = Vector3.Distance(transform.position, transformA.position);
        var distToB = Vector3.Distance(transform.position, transformB.position);

        if (distToA < distToB)
        {
            return transformA; // Why?
        }

        return transformB; // Why?
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
