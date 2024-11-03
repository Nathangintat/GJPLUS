using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipLogic : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private AIPath _enemyPathfinding;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _enemyPathfinding = GetComponent<AIPath>();
    }
    private void Update()
    {
        if(_enemyPathfinding.desiredVelocity.x != 0)
        {
            if (_enemyPathfinding.desiredVelocity.x > 0.01f)
                _spriteRenderer.flipX = false;
            else _spriteRenderer.flipX = true;
        }
    }
}
