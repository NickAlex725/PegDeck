using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Peg : MonoBehaviour
{
    protected PeggleManager _peggleManager;

    protected float disableDelay = 0.15f;

    [Header("Unity Events")]
    public UnityEvent OnEnableUE;
    public UnityEvent OnPegHitUE;

    private void Awake()
    {
        _peggleManager = FindObjectOfType<PeggleManager>();
    }
    private void OnEnable()
    {
        OnEnableUE?.Invoke();
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
        OnPegHitUE?.Invoke();

        //add hit effects in parent
    }

    protected IEnumerator DisablePeg()
    {
        yield return new WaitForSeconds(disableDelay);

        gameObject.SetActive(false);
    }
}
