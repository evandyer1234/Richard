using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemy : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        // If you take enough damage it's time to go
        if (health <= 0)
        {
            Die();
        }

    }

    // This instance of the Enemy is destroyed
    void Die()
    {
        Destroy(gameObject);
    }
}
