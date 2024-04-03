using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peg : MonoBehaviour
{
    protected PeggleManager _peggleManager;

    private void Awake()
    {
        _peggleManager = FindObjectOfType<PeggleManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Ball>())
        {
            OnPegHit();
        }
    }

    public virtual void OnPegHit()
    {
        //add hit effects in parent
    }
}
