using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator),typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Vector2 direction;
    private void Awake() {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        direction = rb.velocity;
        if(direction.x != 0) 
        {
            if(direction.x > 0) sr.FlipX = true;
            else sr.FlipX = false;
            animator.Play("Move Sideways");
        }
        else if (direction.y > 0) animator.Play("Move Up");
        else if (direction.y < 0) animator.Play("Move Down");
        else animator.Play("Idle");
    }
    
}
