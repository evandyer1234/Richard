using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    
    public int damage = 1;
    bool charged = false;
    public float chargedTime = 5f;
    float timeLeft = 0;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = chargedTime;
    }
    void Update()
    {
        if (charged)
        {
            timeLeft -= Time.deltaTime;
        }
        if (timeLeft <= 0)
        {
            charged = false;
            timeLeft = chargedTime;
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        if (hitInfo.transform.tag == "electricity")
        {
            charged = true;
        }
        
    }
    void OnTriggerStay2D(Collider2D hitInfo)
    {
        if (charged)
        {
            MyEnemy enemy = hitInfo.GetComponent<MyEnemy>();
            // Enemy gets destroyed if it takes on too much damage
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
               
            }
        }
    }

    // Disables gravity on all rigidbodies entering this collider.
    
}
