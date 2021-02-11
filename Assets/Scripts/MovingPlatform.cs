using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveDistance = 2f;
    public float MoveSpeed = 3f;
    float startposition;
    bool movingleft = false;
    // Start is called before the first frame update
    void Start()
    {
        startposition = gameObject.transform.position.x;
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.SetParent(transform);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }

    void FixedUpdate()
    {
        if (!movingleft)
        {
            gameObject.transform.position += new Vector3(MoveSpeed, 0, 0);
        }
        if (movingleft)
        {
            gameObject.transform.position += new Vector3(-MoveSpeed, 0, 0);
        }
        if (startposition - moveDistance > gameObject.transform.position.x)
        {
            movingleft = false;
        }
        if (startposition + moveDistance < gameObject.transform.position.x)
        {
            movingleft = true;
        }
    }
}
