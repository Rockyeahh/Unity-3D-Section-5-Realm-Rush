using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    // public is ok here as this is a data class.
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;

    [SerializeField] Color exploredColor;

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
        if (Input.GetMouseButtonDown(0) && isPlaceable == true) // 0 = left click // I could also use the input manager.
        {
            //print(gameObject.name + " clicked & isPlaceable");
            FindObjectOfType<TowerFactory>().AddTower(this);
        } else
        {
            print ("Can't place here.");
        }
    }
}
