using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseEntity
{
    private const float P_SPEED_NORMAL = 300f;
    private const float P_SPEED_SLOWED = 100f;
    private const float P_FRICTION = 0.2f;
    private const float JUMP_HEIGHT = 3f;

    public float jumpForce = -2f;
    private float speed;
    private float currentSpeed;

    //public new float startHits;

    public override void Start()
    {
        startHits = 6;
        base.Start();

        InputManager.jumpInput += Jump;
    }
    public override void MoveEntity()
    {
        float hor = Input.GetAxis("Horizontal");
        speed = hor * currentSpeed * Time.deltaTime;

        movementVector.x += speed * Time.deltaTime;
        movementVector.x -= P_FRICTION * movementVector.x;

        base.MoveEntity();
    }

    public void Jump()
    {
        if (controller.isGrounded)
            movementVector.y = Mathf.Sqrt(JUMP_HEIGHT * jumpForce * G_CONSTANT);
    }

    public override void ApplyEffects()
    {
        base.ApplyEffects();

        currentSpeed = isSlowed ? P_SPEED_SLOWED : P_SPEED_NORMAL;                      //The SLOWNESS effect.
    }
}
