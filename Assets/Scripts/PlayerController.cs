using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float speedX;
    public float speedY;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    public int maxplayerHealth = 100;
    public int currentHealth = 0;
    public int playerHitPower = 10;
    public Transform playerHitRadius;

    void Start()
    {
        currentHealth = maxplayerHealth;
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        speedX = Input.GetAxisRaw("Horizontal");
        speedY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(speedX, speedY).normalized;
        rb.velocity = moveDirection * moveSpeed;

    }


    // Controls the max and min health of the player
    private void UpdateHealth(int mod){
        currentHealth += mod;

        if (currentHealth > maxplayerHealth){
            currentHealth = maxplayerHealth;
        } else if (currentHealth <= 0) {
            currentHealth = 0;
            Debug.Log("Player Respawn");
        }
    }

    
}
