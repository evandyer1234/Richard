using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoke : MonoBehaviour
{
    public float TimeLeft = 1f;
    public float RotationRate = 200f;
    public float size = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TimeLeft -= Time.fixedDeltaTime;
        gameObject.transform.Rotate(RotationRate * Time.deltaTime * gameObject.transform.forward);
        transform.localScale -= new Vector3(size, size, 0) * Time.deltaTime;
        if (TimeLeft <= 0)
        {
            Destroy(gameObject);
        }
    }
}
