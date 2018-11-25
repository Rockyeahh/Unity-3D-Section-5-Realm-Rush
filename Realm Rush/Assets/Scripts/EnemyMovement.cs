using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] float movementPeriod = .5f;
    [SerializeField] ParticleSystem goalParticle;

    void Start () {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>(); // Only works as long as we have one Pathfinder script in the scene.
        var path = pathfinder.GetPath(); // Change var to List of waypoints.
        StartCoroutine(FollowPath(path));
	}

    IEnumerator FollowPath(List<Waypoint> path) // I think you can access lists from any script.
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementPeriod); // moves the enemy each second.
        }
        SelfDestruct();
    }

    private void SelfDestruct()
    {
        var vfx = Instantiate(goalParticle, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);

        Destroy(gameObject); // destroy enemy
    }

}
