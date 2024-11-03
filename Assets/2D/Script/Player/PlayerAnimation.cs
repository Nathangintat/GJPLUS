using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator),typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sr;
    private void Awake() {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    public void Walk(Vector2 direction) {
        Debug.Log(direction);
        if(direction.x != 0) 
        {
            if(direction.x > 0) sr.flipX = false;
            else sr.flipX = true;
            animator.Play("Move Sideways");
        }
        else if (direction.y > 0) animator.Play("Move Up");
        else if (direction.y < 0) animator.Play("Move Down");
        else animator.Play("Idle");
    }
}
