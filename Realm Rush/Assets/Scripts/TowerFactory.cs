using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParentTransform;

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
        newTower.transform.parent = towerParentTransform;
        baseWaypoint.isPlaceable = false; // baseWaypoint acts as the waypoint script reference here for the isPlaceable code. // set the placeable flags.

        newTower.baseWaypoint = baseWaypoint; // It tells the new tower that it's baseWaypoint is the same as the baseWaypoint in this method.
        baseWaypoint.isPlaceable = false;

        queueTowers.Enqueue(newTower);
    }

    private void MoveExistingTowers(Waypoint newBaseWaypoint) // Moves the towers rather than destroying and re-creating new ones.
    {
        var oldTower = queueTowers.Dequeue();

        oldTower.baseWaypoint.isPlaceable = true; // free up the block/make it placeable again.
        newBaseWaypoint.isPlaceable = false; // Makes the new waypoint/block not placeable.

        oldTower.baseWaypoint = newBaseWaypoint; // Sets the old waypoint to it's new waypoint.

        oldTower.transform.position = newBaseWaypoint.transform.position; // Moves the dequeued old tower to the newBaseWaypoint. 

        queueTowers.Enqueue(oldTower); // Puts the old tower back on the top of the queue.
    }
}
