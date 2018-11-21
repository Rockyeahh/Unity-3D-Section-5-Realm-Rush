using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;

    int numTowers = 0;

    public void AddTower (Waypoint baseWaypoint)
    {
        if (numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTowers();
        }
    }

    private static void MoveExistingTowers()
    {
        Debug.Log("You can't place anymore towers.");
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlaceable = false; // baseWaypoint acts as the waypoint script reference here for the isPlaceable code.
        numTowers++;
    }
}
