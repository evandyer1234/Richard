using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bits : MonoBehaviour
{
    public Rigidbody2D rb;
    float rando = 0f;
    float randoY = 0f;
    public float lifeTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        rando = Random.Range(-1.0f, 1.0f);
        randoY = Random.Range(-1.0f, 3.0f);
        rb.velocity = new Vector3(rando, randoY, 0f);
    }
    void FixedUpdate()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
