using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    Vector2Int gridPos;

    const int gridSize = 10;

    void Start () {
		
	}

    public int GetGridSize() // Gets it from the Cube Editor.
    {
        return gridSize;
    }

    public Vector2 GetGridPos()
    {
        return new Vector2Int( // Vectore2Int pairs two ints together.
        Mathf.RoundToInt(transform.position.x / gridSize) * gridSize, // Rounds up to a whole Int number in x divide by 10 int. Then multiply by 10.
                                                                      // How? The 10 is the size of the block in x axis. And divided by 10 makes .625 as an example.
                                                                      // Then it's rounded up to the whole number and then multiplied to 6 in order to be big enough again.
        Mathf.RoundToInt(transform.position.z / gridSize) * gridSize
        );
    }
	
	void Update () {
		
	}
}
