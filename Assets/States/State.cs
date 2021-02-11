using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected Player player;

    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual IEnumerator Run()
    {
        yield break;
    }

    public virtual IEnumerator GroundAttack()
    {
        yield break;
    }

    public virtual IEnumerator Jump()
    {
        yield break;
    }

    public virtual IEnumerator Idle()
    {
        yield break;
    }
}
