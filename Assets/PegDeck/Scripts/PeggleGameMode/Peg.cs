using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Peg : MonoBehaviour
{
    protected PeggleManager _peggleManager;

    protected float disableDelay = 0.1f;

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

    protected IEnumerator DisablePeg()
    {
        yield return new WaitForSeconds(disableDelay);

        gameObject.SetActive(false);
    }
}
