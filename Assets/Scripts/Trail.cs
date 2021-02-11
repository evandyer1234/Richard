using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    public float size = 20;
    public float timer = 1f;
    float currentSize = 1;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
            timer -= Time.deltaTime;
        gameObject.transform.localScale -= new Vector3(size, size, 0) * Time.deltaTime;
        currentSize = currentSize - size;

        if (timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void Awake()
    {
       
    }
    void FixedUpdate()
    {
        
    }
}
