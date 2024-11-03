using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterKillLogic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerDeath>().Die();
            collision.attachedRigidbody.simulated = false;
        }
    }
}
