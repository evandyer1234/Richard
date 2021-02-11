using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRegen : MonoBehaviour
{
    public GameObject Block;
    bool countdown = false;
    float currentTime;
    public float RegenTime = 4f;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = RegenTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (countdown)
        {
            currentTime -= Time.fixedDeltaTime;
        }
        if (currentTime <= 0)
        {
            Block.SetActive(true);
            currentTime = RegenTime;
            countdown = false;
        }
    }
    public void startTime()
    {
        countdown = true;
    }
}
