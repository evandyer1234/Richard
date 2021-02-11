using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heated : MonoBehaviour
{
    public int damage = 1;
    public Fire fire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D hitInfo)
    {
        MyEnemy enemy = hitInfo.GetComponent<MyEnemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        MyEnemy enemy = hitInfo.GetComponent<MyEnemy>();
        if (enemy != null)
        {
            Fire clone = (Fire)Instantiate(fire, hitInfo.transform.position, hitInfo.transform.rotation);
        }
    }
}
