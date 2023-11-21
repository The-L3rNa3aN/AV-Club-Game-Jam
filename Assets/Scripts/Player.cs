using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseEntity
{
    private const float P_SPEED = 300f;
    private const float P_FRICTION = 0.2f;
    private const float JUMP_HEIGHT = 3f;

    public float jumpForce = -2f;
    private float speed;

    public override void Start()
    {
        base.Start();

        InputManager.jumpInput += Jump;
    }
    public override void MoveEntity()
    {
        float hor = Input.GetAxis("Horizontal");
        speed = hor * P_SPEED * Time.deltaTime;

        movementVector.x += speed * Time.deltaTime;
        movementVector.x -= P_FRICTION * movementVector.x;

        base.MoveEntity();
    }

    public void Jump()
    {
        if (controller.isGrounded)
            movementVector.y = Mathf.Sqrt(JUMP_HEIGHT * jumpForce * G_CONSTANT);
    }
}
