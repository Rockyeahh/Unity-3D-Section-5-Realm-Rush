using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] int playerHealth = 10;
    [SerializeField] int playerHealthDecrease = 1;
    [SerializeField] Text healthText;

    void Start()
    {
        healthText.text = playerHealth.ToString();
    }

    void OnTriggerEnter(Collider collider)
    {
        playerHealth -= playerHealthDecrease; // playerHealth is playerHealth - playerHealthDecrease.
        healthText.text = playerHealth.ToString();
        if (playerHealth <= 0)
        {
            PlayerDies();
        }
    }

    private void PlayerDies()
    {
        print("Player dies");
    }
}
