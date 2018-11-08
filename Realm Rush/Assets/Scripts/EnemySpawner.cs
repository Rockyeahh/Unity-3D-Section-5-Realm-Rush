using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyToSpawn;

	void Start () {
        StartCoroutine(RepeatedlySpawnEnemies());
        print("start coroutine enemy spawner");
	}

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) // true is true by default so using it make something spawn forever is fine and it's less typing than an if statement.
        {
        Instantiate(enemyToSpawn, new Vector3(0, 0, 0), Quaternion.identity); // Needs a different transform.
        yield return new WaitForSeconds(secondsBetweenSpawns);
        print("instantiate enemies");
        }
    }
}
