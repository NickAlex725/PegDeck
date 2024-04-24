using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Peg : MonoBehaviour
{
    protected PeggleManager _peggleManager;

    protected float disableDelay = 0.15f;
    protected bool _canBeHit = true;

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
        _canBeHit = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Ball>())
        {
            if (_canBeHit)
            {
                _canBeHit = false;
                OnPegHit();
            }
        }
    }

    public virtual void OnPegHit()
    {
        OnPegHitUE?.Invoke();

        AudioSFX.Instance.PlaySoundEffect(SFXType.PegHit);
        //add hit effects in parent
    }

    protected IEnumerator DisablePeg()
    {
        yield return new WaitForSeconds(disableDelay);

        gameObject.SetActive(false);
    }

    public void EnableHit(bool canBeHit)
    {
        _canBeHit = canBeHit;
    }
}
