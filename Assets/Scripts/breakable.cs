using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakable : MonoBehaviour
{
    public Bits bits;
    public AudioSource source;
    public AudioClip pap;
    public float hitVol = 5f;
    public bool regen = false;
    public GameObject Parent;
    
    
    public void Break()
    {

        source.PlayOneShot(pap, hitVol);
        Bits clone = (Bits)Instantiate(bits, gameObject.transform.position, gameObject.transform.rotation);
            Bits clone2 = (Bits)Instantiate(bits, gameObject.transform.position, gameObject.transform.rotation);
            Bits clone3 = (Bits)Instantiate(bits, gameObject.transform.position, gameObject.transform.rotation);
        if (regen)
        {
            BlockRegen blockRegen = Parent.GetComponent<BlockRegen>();
            blockRegen.startTime();
        }
            gameObject.SetActive(false);
        
    }
}
