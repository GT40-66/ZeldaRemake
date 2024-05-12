using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    public static HUDController instance;
    public TMPro.TMP_Text healthText;
    private PlayerController playerController;
    public int currentPlayerHealth;
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        currentPlayerHealth = playerController.currentHealth;
        healthText.text = "Health: " + currentPlayerHealth.ToString();
    }        

    // Update is called once per frame
    void Update()
    {
        PlayerHealth();
    }
    private void PlayerHealth()
    {
        currentPlayerHealth = playerController.currentHealth;
        healthText.text = "Health: " + currentPlayerHealth.ToString();
    }
}
