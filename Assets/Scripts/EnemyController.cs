using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public float speed = 3f;
    private float distance;
    private float enemyDistance;
    public float distanceBetween;
    private Transform target;
    public int enemyHit = 5;
    public int enemyHealth;
    public int enemyMaxHealth = 40;
    public Transform enemyRadius; 
    public HealthBarBehavior healthBar;
    private PlayerController playerController;

    void Start()
    {
        enemyHealth = enemyMaxHealth;
        healthBar.SetHealth(enemyHealth, enemyMaxHealth);
    }
    private void Update() {
        EnemyMovement();
        EnemyDeath();
        HitEnemy();
       
    }

    private void EnemyMovement(){
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

    

        if(distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }

    private void EnemyDeath(){
        if (enemyHealth <= 0){
            Destroy(gameObject);
        }
    }

        // Controls input and min distance to enemy to inflict damage
    private void HitEnemy()
    {
        if (playerController == null)
        {
            // Find the PlayerController component in the scene
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (playerController != null)
            {
                // Calculate the distance between player's hit radius and enemy radius
                float enemyDistance = Vector2.Distance(playerController.playerHitRadius.position, enemyRadius.position);
                // Check if the distance is within the range to hit the enemy
                if (enemyDistance <= 2)
                {
                    healthBar.SetHealth(enemyHealth, enemyMaxHealth);
                    enemyHealth -= playerController.playerHitPower;
                }
            }
        }
    }

}

