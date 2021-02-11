using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bards : MyEnemy
{
    public GameObject target;
    GameObject currentTarget;
    public int damage = 10;
    public float MoveSpeed = 8f;
    public float MaxDistance = 10f;
    bool isMoving = true;
    public GameObject StartLocation;
    public smoke dust;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        currentTarget = StartLocation;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(target.transform.position, transform.position);
        if (distance <= MaxDistance)
        {
            currentTarget = target;
        }
        else
        {
            currentTarget = StartLocation;
        }
    }
    void FixedUpdate()
    {
        if (isMoving)
        {
            if (currentTarget.transform.position.x > gameObject.transform.position.x)
            {
                gameObject.transform.position += new Vector3(MoveSpeed, 0, 0);
            }
            if (currentTarget.transform.position.x < gameObject.transform.position.x)
            {
                gameObject.transform.position += new Vector3(-MoveSpeed, 0, 0);
            }
            if (currentTarget.transform.position.y > gameObject.transform.position.y)
            {
                gameObject.transform.position += new Vector3(0, MoveSpeed, 0);
            }
            if (currentTarget.transform.position.y < gameObject.transform.position.y)
            {
                gameObject.transform.position += new Vector3(0, -MoveSpeed, 0);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Character1 character1 = collision.GetComponent<Character1>();
            character1.Damage(damage);
        }
        if (collision.transform.tag == "hitbox")
        {
            smoke clone = (smoke)Instantiate(dust, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
