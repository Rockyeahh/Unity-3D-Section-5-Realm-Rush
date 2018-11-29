using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] int playerHealth = 10;
    [SerializeField] int playerHealthDecrease = 1;

    void OnTriggerEnter(Collider collider)
    {
        playerHealth = playerHealth - playerHealthDecrease; // playerHealth is playerHealth - playerHealthDecrease.
        //playerHealth--;
        print(playerHealth);
        if (playerHealth <= 0)
        {
            playerDies();
        }
    }

    private void playerDies()
    {
        print("Player dies");
    }
}
