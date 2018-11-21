using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;

    Queue<Tower> queueTowers = new Queue<Tower>();

    public void AddTower (Waypoint baseWaypoint)
    {
        int numTowers = queueTowers.Count;

        if (numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTowers(baseWaypoint);
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlaceable = false; // baseWaypoint acts as the waypoint script reference here for the isPlaceable code. // set the placeable flags.

        // set the baseWaypoints.

        queueTowers.Enqueue(newTower);
        print("towers queue " + queueTowers.Count);
    }

    private void MoveExistingTowers(Waypoint baseWaypoint)
    {
        var oldTower = queueTowers.Dequeue();

        // set the placeable flags. isPlaceable = 
        //baseWaypoint.isPlaceable = true;
        // set the baseWaypoints.

        queueTowers.Enqueue(oldTower); // Puts the old tower back on the top of the queue.
    }
}
