using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    
    public GameObject self;
    public float RotationRate = 100;
    public AudioClip bling;
    public AudioSource source;
    public float hitVol = 5f;
    public Twinkle twinkle;
    
    void Update()
    {
        gameObject.transform.Rotate(RotationRate * Time.deltaTime * Vector2.up);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Twinkle clone = (Twinkle)Instantiate(twinkle, gameObject.transform.position, Quaternion.identity);
            clone.startx = gameObject.transform.position.x;
            clone.starty = gameObject.transform.position.y;
            clone.isClone = true;

            Twinkle clone2 = (Twinkle)Instantiate(twinkle, gameObject.transform.position, Quaternion.identity);
            clone2.startx = gameObject.transform.position.x;
            clone2.starty = gameObject.transform.position.y;
            clone2.isClone = true;

            Twinkle clone3 = (Twinkle)Instantiate(twinkle, gameObject.transform.position, Quaternion.identity);
            clone3.startx = gameObject.transform.position.x;
            clone3.starty = gameObject.transform.position.y;
            clone3.isClone = true;

            source.PlayOneShot(bling, hitVol);
            Destroy(self);
        }
    }
}
