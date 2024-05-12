using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1f;
    private Transform target;
    public int enemyHit = 5;
    public int enemyHealth = 40;
    public Transform enemyRadius; 

    private void Update() 
    {
        if (target != null) {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
        EnemyHealth();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            target = other.transform;

            Debug.Log(target);
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "Player") {
            target = null;
        }
    }

    private void EnemyHealth()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    
}
