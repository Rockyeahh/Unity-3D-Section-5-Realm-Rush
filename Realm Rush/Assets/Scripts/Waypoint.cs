using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    [SerializeField] Color exploredColor;

    // public is ok here as this is a data class.
    public bool isExplored = false;
    public Waypoint exploredFrom;

    Vector2Int gridPos;

    const int gridSize = 10;

    public int GetGridSize() // Gets it from the Cube Editor.
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int( // Vectore2Int pairs two ints together.
        Mathf.RoundToInt(transform.position.x / gridSize), // Rounds up to a whole Int number in x divide by 10 int.
        Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    void OnMouseOver()
    {
        print(gameObject.name);
    }

    // public void SetTopColour(Color color)
    //{
    //  MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>(); // Finds all the mesh renderers, that contain the colours.
    //topMeshRenderer.material.color = color; // Sets the colour to whatever colour has been sent to this method from the waypoint script.
    //}
}
