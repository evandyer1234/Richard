using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownDashHitBox : MonoBehaviour
{
    public GameObject Player;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Character1 character1 = Player.GetComponent<Character1>();
        breakable broke = collision.gameObject.GetComponent<breakable>();
        if (collision.transform.tag != "breakable")
        {
            character1.DownDash();
            
            gameObject.SetActive(false);
        }
        if (broke != null)
        {
            broke.Break();
        }
    }
}
