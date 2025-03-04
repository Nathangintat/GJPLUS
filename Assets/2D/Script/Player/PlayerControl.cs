using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 4f;
    [SerializeField] private float verticalSpeedModifier;
    private PlayerInpu input;
    private Vector2 direction;
    private Rigidbody2D rb;
    private PlayerAnimation playerAnimation;

    private void Awake()
    {
        input = new PlayerInpu();
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    void Update()
    {
        direction = input.Player.Move.ReadValue<Vector2>().normalized;
        playerAnimation.Walk(direction);
        if (direction.magnitude != 0)
        {
            rb.velocity = new Vector2(direction.x * movementSpeed, (direction.y * movementSpeed) / verticalSpeedModifier);
            
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
