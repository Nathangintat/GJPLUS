using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed = 2f;
    [SerializeField] private float verticalSpeed = 1f;
    private PlayerInpu input;
    private Vector2 direction;
    [SerializeField] Rigidbody2D rb;

    private void Awake()
    {
        input = new PlayerInpu();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        direction = input.Player.Move.ReadValue<Vector2>().normalized;
        if (direction.magnitude != 0)
        {
            rb.velocity = new Vector2(direction.x * horizontalSpeed, direction.y * verticalSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
