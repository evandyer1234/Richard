using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonTrigger : MonoBehaviour
{
    public GameObject canons;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Canon canon = canons.GetComponent<Canon>();
            canon.StartLaunch();
        }
    }
}
