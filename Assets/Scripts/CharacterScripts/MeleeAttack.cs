using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public int damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        MyEnemy enemy = hitInfo.GetComponent<MyEnemy>();
        // Enemy gets destroyed if it takes on too much damage
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
           
        }
        // Bullet destroys itself

    }
}
