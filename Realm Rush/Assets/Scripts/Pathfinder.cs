﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter; // the current searchCenter
    List<Waypoint> path = new List<Waypoint>();

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0) // Solves the "if not already calculated" issue in the Subtleties Of Spawning video.
        {
            CalculatePath();
        }
        return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        BreadthFirstSearch();
        CreathPath();
    }

    private void LoadBlocks() // All the commented out code above lines is Ben's code.
    {
        Waypoint[] waypoints = GetComponentsInChildren<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            bool isOverlapping = grid.ContainsKey(waypoint.GetGridPos()); // Contains key checks if there is another key. How does it not check it's own key? Can it not see/find itself?
            if (isOverlapping)
            {
                Debug.LogWarning("Skipping overlapping Block " + waypoint);
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint); // Adds the waypoint and the grid position of the waypoint to the waypoints Array.
            }
        }
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue(); // searchCenter means search the surrounding directions? No maybe it's just a thing that stores the dequeing of the queue and he's named it badly.
            HaltIfEndFound();
            ExploreNeighbours();
            searchCenter.isExplored = true;
        }
    }

    private void CreathPath()
    {
        SetAsPath(endWaypoint); // Why is it endWaypoint all the time? Why not just waypoint? maybe it means the waypoint has ended rather than the last/end goal waypoint in the scene.

        Waypoint previous = endWaypoint.exploredFrom;
        while (previous != startWaypoint)
        {
            SetAsPath(previous);
            previous = previous.exploredFrom; // Tells previous to be exploredFrom rather than by endWaypoint.exploredFrom. Otherwise it stays in a loop.
        }

        SetAsPath(startWaypoint);
        path.Reverse(); // Reverses the list.
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == endWaypoint)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning){ return; } // Stops it from exploring neighbours when it's not running.
    
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction; // Adds the current start position to the direction it can move in.
            if (grid.ContainsKey(neighbourCoordinates))
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
        }
    }

    private void SetAsPath(Waypoint waypoint)
    {
        path.Add(waypoint);
        waypoint.isPlaceable = false; // stops you being able to add Enemies directly onto the end goal.

    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {
            // do nothing
        }
        else 
        {
        queue.Enqueue(neighbour);
        neighbour.exploredFrom = searchCenter;
        }
    }
}
