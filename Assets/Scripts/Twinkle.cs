using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twinkle : MonoBehaviour
{
    public float size = 10f;
    public double timer = 2;
    public double startTime = 2;
    public float startx;
    public float starty;
    public bool isClone = false;
    float currentSize = 1;
    public float variration;
    
    void Start()
    {
        timer = startTime;
    }
    void Awake()
    {
        float rando = Random.Range(-variration, variration);
        float randoY = Random.Range(-variration, variration);
        gameObject.transform.position += new Vector3(rando, randoY, 0);
    }
    
    void FixedUpdate()
    {
        if (isClone)
        {
            transform.localScale -= new Vector3(size, size, 0) * Time.deltaTime;
            currentSize = currentSize - size;

            if (timer < 0)
            {
                Destroy(gameObject);
            }
        }
        timer -= Time.deltaTime;
    }
}
