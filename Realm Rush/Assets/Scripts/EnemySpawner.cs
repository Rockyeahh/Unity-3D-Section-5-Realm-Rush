using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] GameObject enemyToSpawn;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnEnemies(secondsBetweenSpawns));
	}

    IEnumerator SpawnEnemies() {if (secondsBetweenSpawns <= 0)
        {
            yield return new WaitForSeconds(1);
            //or just Instantiate (enemyToSpawn, Vector3 stuff, Quaternion.identity);
            Instantiate(enemyToSpawn, new Vector3(0, 0, 0), Quaternion.identity); // May need a different transform.
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
