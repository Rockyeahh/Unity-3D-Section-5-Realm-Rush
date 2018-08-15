using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour {

    [SerializeField] [Range (1f, 20f)] float gridSize = 10f; // Range restricts the values that can be set in the inspector to between 1 and 20 float.
                                                            // Why 20? Incase you need space for cubes smaller than 10f.

    void Update()
        {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize; // Rounds up to a whole Int number in x divide by 10 float. Then multiply by 10.
                                                                        // How? The 10 is the size of the block in x axis. And divided by 10 makes .625 or whatever.
                                                                        // Then it's rounded up to the whole number and then multiplied to 6 in order to be big enough again.
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize; // Need to work this out like the above x position.

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
        }
}
