using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] List<Waypoint> path;

	void Start () {
        StartCoroutine(FollowPath());
        print("I'm at the start again.");
	}

    IEnumerator FollowPath()
    {
        print ("Starting Patrol");
        foreach (Waypoint waypoint in path)
        {

            transform.position = waypoint.transform.position;
            print ("Visiting Block " + waypoint);
            yield return new WaitForSeconds(1f); // moves the enemy each second.
        }
        print("Ending Patrol");
    }
}
