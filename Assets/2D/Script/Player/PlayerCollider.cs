using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Interactable"))
        {
            other.GetComponent<IInteractable>().Interact();
        }
        else if(other.CompareTag("Enemy"))
        {
            GetComponent<PlayerDeath>().Die();
        }
        else
        {
            return;
        }
    }
}
