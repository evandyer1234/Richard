using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : StateMachine
{
    public virtual void Start()
    {

    }

    public virtual void Idle()
    {

    }

    public virtual void Run()
    {
        StartCoroutine(State.Run());
    }
}
