using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase] // Makes it so you end selecting the parent object rather than the child object.
[RequireComponent (typeof(Waypoint))]
public class CubeEditor : MonoBehaviour {

    // old code [SerializeField] [Range (1f, 20f)] float gridSize = 10f; // Range restricts the values that can be set in the inspector to between 1 and 20 float.
    // Why 20? Incase you need space for cubes smaller than 10f.

    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>(); // Finds the waypoint so that it can be dependent on it.
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(waypoint.GetGridPos().x, 0f, waypoint.GetGridPos().y); // Uses y instead of z because it's 2D?.
    }

    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        int gridSize = waypoint.GetGridSize();
        string labelText = waypoint.GetGridPos().x / gridSize + "," + waypoint.GetGridPos().y / gridSize; // It divides by grid size here so that you end up with whole numbers in the text.
        textMesh.text = labelText;
        gameObject.name = "Block " + labelText;
    }
}
