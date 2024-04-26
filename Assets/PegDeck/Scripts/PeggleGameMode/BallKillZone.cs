using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallKillZone : MonoBehaviour
{
    private PeggleManager _peggleManager;

    public Action OnBallTrigger = delegate { };
    private void Awake()
    {
        _peggleManager = FindObjectOfType<PeggleManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Ball>())
        {
            // transition level and peggle state
            Destroy(collision.gameObject);

            //sfx
            AudioSFX.Instance.PlaySoundEffect(SFXType.BallDeath);

            OnBallTrigger?.Invoke();
        }
    }
}
