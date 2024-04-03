using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallKillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Ball>())
        {
            // transition level and peggle state
            Destroy(collision.gameObject);
        }
    }
}