using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    [Range (0.1f, 120f)] // Why? I think he said it stops the bellow code trying to use 0, which can cause errors? I don't know.
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyToSpawn;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] Text scoreText;
    [SerializeField] AudioClip spawnedEnemySFX;

    int enemyCount;

    void Start () {
        StartCoroutine(RepeatedlySpawnEnemies());
        scoreText.text = enemyCount.ToString();
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) // true is true by default so using it make something spawn forever is fine and it's less typing than an if statement.
        {
            AddScore();
            PlaySpawningAudio();
            var newEnemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity); // Does this child the Enemy game object?
            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void AddScore()
    {
        enemyCount++;
        scoreText.text = enemyCount.ToString();
    }

    private void PlaySpawningAudio()
    {
        GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
    }
}
