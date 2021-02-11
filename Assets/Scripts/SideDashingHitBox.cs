using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideDashingHitBox : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Character1 character1 = Player.GetComponent<Character1>();
        breakable broke = collision.gameObject.GetComponent<breakable>();
        if (collision.transform.tag != "breakable" && collision.transform.tag != "slippery")
        {
            character1.SideDash();
            character1.sideStuck = true;
            gameObject.SetActive(false);
            Player.transform.SetParent(collision.transform);
        }
        if (collision.transform.tag == "breakable")
        {
            character1.currentDashTime = character1.dashTime;
            broke.Break();
        }
        if (broke != null)
        {
            broke.Break();
        }
    }
}
