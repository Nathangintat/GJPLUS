using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAgro : MonoBehaviour
{
    [SerializeField] private AIPath _enemyPathfinding;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _enemyPathfinding.canMove = true;
        }
    }
}
