using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    // Use this for initialization
    void Start () {
        LoadBlocks();
	}

    private void LoadBlocks() // All the commented out code above lines is Ben's code.
    {
        //var waypoints = FindObjectOfType<Waypoint>();
        Waypoint[] waypoints = GetComponentsInChildren<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            // var gridPos = waypoint.GetGridPos();
            // if (grid.ContainsKey(gridPos))
            bool isOverlapping = grid.ContainsKey(waypoint.GetGridPos()); // Contains key checks if there is another key. How does it not check it's own key? Can it not see/find itself?
            if (isOverlapping)
            {
                Debug.LogWarning("Skipping overlapping Block " + waypoint);
            } else
            {
                // grid.Add(gridPos, waypoint);
                grid.Add(waypoint.GetGridPos(), waypoint); // Adds the waypoint and the grid position of the waypoint to the waypoints Array.
            }
        }
        print("Loaded " + grid.Count + " Blocks");
    }
}
