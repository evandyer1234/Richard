using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject point;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Character1 character1 = collision.GetComponent<Character1>();
            character1.SpawnX = point.transform.position.x;
            character1.SpawnY = point.transform.position.y;
        }
    }

}
