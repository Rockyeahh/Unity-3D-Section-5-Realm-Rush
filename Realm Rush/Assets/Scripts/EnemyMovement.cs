using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    void Start () {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>(); // Only works as long as we have one Pathfinder script in the scene.
        var path = pathfinder.GetPath(); // Change var to List of waypoints.
        StartCoroutine(FollowPath(path));
	}

    IEnumerator FollowPath(List<Waypoint> path) // I think you can access lists from any script.
    {
        print("Starting Patrol");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(2f); // moves the enemy each second.
        }
        print("Ending Patrol");
    }
}
