using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    private int healPoints = 10;
    private PlayerController playerController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (playerController != null && Input.GetMouseButtonDown(0) && playerController.currentHealth != playerController.maxplayerHealth)
       {
            playerController.currentHealth += healPoints;
            Destroy(gameObject);
       }
    }
  
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerController = other.GetComponent<PlayerController>();
        }
    }
}
    
