using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swirl : MonoBehaviour
{
    public float RotationRate = 100f;
    public bool left;
    public bool right;
    float direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (left)
        {
            direction = -1;
        }
        if (right)
        {
            direction = 1;
        }
        if (!left && !right)
        {
            direction = 0;
        }
        gameObject.transform.Rotate(direction * RotationRate * Time.deltaTime * gameObject.transform.forward);

    }
}
