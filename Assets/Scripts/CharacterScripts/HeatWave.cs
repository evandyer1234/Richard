using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatWave : MonoBehaviour
{
    public float size = 20;
    public int damage = 50;
    public double timer = 2;
    public double startTime = 2;
    
   
    float currentSize = 1;
    // Start is called before the first frame update
    void Start()
    {
        timer = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        
    }
    void FixedUpdate()
    {
        transform.localScale += new Vector3(size, size, 0) * Time.deltaTime;
        currentSize = currentSize + size;

        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        FireBridge fire = collision.GetComponent<FireBridge>();
        if (fire != null)
        {
            fire.burning = true;
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        MyEnemy enemy = hitInfo.GetComponent<MyEnemy>();
        
        if (enemy != null)
        {
            enemy.TakeDamage(damage);

        }
    }
}
