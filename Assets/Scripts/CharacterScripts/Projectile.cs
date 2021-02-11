using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool clone = false;
    Transform transf;
    Rigidbody2D rb;
    public float MoveRate;
    public float direction;
    public float speed;
    public int damage;
    public int destroyTime = 1;
    float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = destroyTime;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (clone)
        {
            currentTime -= Time.deltaTime;
        }
        if (currentTime <= 0)
        {
            Destroy(gameObject);
        }
        MoveForward(direction);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (clone)
        {
            
                Destroy(gameObject);
            
        }
    }
    public void MoveForward(float value)
    {
        if (clone)
        {
            Vector2 location = rb.position;

            location += (value * MoveRate * Time.fixedDeltaTime * Vector2.right);


            rb.position = location;
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        MyEnemy enemy = hitInfo.GetComponent<MyEnemy>();
        // Enemy gets destroyed if it takes on too much damage
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(this.gameObject);
        }
        // Bullet destroys itself
        
    }
}
