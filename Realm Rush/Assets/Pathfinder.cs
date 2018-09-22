using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    }; // Why is the ; here? How/why does it work here and not in other methods.

    // Use this for initialization
    void Start () {
        LoadBlocks();
        ColourStartAndEnd();
        ExploreNeighbours();
	}

    private void ExploreNeighbours()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = startWaypoint.GetGridPos() + direction; // Adds the current start position to the direction it can move in.
            print("Exploring " + explorationCoordinates); // prints the target space that the enemy will move to in that direction.
            try
            {
                grid[explorationCoordinates].SetTopColour(Color.red); // grid is a dictionary that looks up exploration coordinates and then sets the colour to the possible cube directions.
            }
            catch
            {
                // Do nothing for now.
            }
        }
    }

    private void ColourStartAndEnd()
    {
        startWaypoint.SetTopColour(Color.black);
        endWaypoint.SetTopColour(Color.cyan);
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
        //print("Loaded " + grid.Count + " Blocks");
    }
}
