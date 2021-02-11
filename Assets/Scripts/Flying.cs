using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    public float RotationRate = 300f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position += new Vector3(0, 0.4f, 0);
        gameObject.transform.Rotate(RotationRate * Time.fixedDeltaTime * Vector3.forward);
    }
}
