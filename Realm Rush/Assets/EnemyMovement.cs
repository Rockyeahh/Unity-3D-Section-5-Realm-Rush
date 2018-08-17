﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] List<Block> path;

	void Start () {
        PrintAllWaypoints();
	}

    private void PrintAllWaypoints()
    {
        foreach (Block waypoint in path)
        {
            print(waypoint.name);
        }
    }

    void Update () {
		
       // foreach (Block block in path)
       // {
       //     print(block);
       // }

	}
}
