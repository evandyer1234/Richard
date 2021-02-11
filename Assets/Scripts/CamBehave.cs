using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBehave : MonoBehaviour
{
    public GameObject Player;
    public float maxX = 1f;
    public float MaxY = 1f;
    public float MoveSpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, gameObject.transform.position.z);
        
    }
}
