using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBridge : MonoBehaviour
{
    Animator anim;
    public GameObject HitBox;
    public bool burnAway = true;
    public float burnTime = 2f;
    public float timeleft;
    public float igniteTime = 1f;
    public bool burning = false;
    public GameObject Fire;
    
    void Start()
    {
        timeleft = burnTime;
        HitBox.SetActive(false);
        Fire.SetActive(false);
    }

    
    void Update()
    {
        if (timeleft <= 0)
        {
            Destroy(this.gameObject);
        }
        if (burning)
        {
            igniteTime -= Time.deltaTime;
            if (igniteTime <= 0)
            {
                if (burnAway)
                {
                    Fire.SetActive(true);
                    HitBox.SetActive(true);
                    timeleft -= Time.deltaTime;
                    
                }                
            }            
        }      
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "heat")
        {
            burning = true;
            
            HitBox.SetActive(true);
        }
        if (collision.transform.tag == "water")
        {
            burning = false;
            timeleft = burnTime;
        }
    }

    public void Burn()
    {
        burning = true;

        HitBox.SetActive(true);
    }
}
