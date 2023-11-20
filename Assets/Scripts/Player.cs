using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseEntity
{
    private const float MAX_ACCEL = 100f;
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

        if (speed > MAX_ACCEL) speed = MAX_ACCEL;

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

/*[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private const float MAX_ACCEL = 100f;
    private const float P_SPEED = 300f;
    private const float P_FRICTION = 0.2f;
    private const float G_CONSTANT = -20f;
    private const float JUMP_HEIGHT = 3f;

    [SerializeField] private int hitCount;
    private float speed;
    private Vector3 movementVector;
    private CharacterController controller;
    public float jumpForce = -2f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        *//*InputManager.leftInput += MoveLeft;
        InputManager.rightInput += MoveRight;*//*
        InputManager.jumpInput += Jump;
    }

    private void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        speed = hor * P_SPEED * Time.deltaTime;

        if(speed > MAX_ACCEL) speed = MAX_ACCEL;

        if (controller.isGrounded && movementVector.y < 0f)
            movementVector.y = -2f;

        *//*if (Input.GetButtonDown("Jump") && controller.isGrounded)
            Jump();*//*

        movementVector.x += speed * Time.deltaTime;
        movementVector.x -= P_FRICTION * movementVector.x;
        movementVector.y += G_CONSTANT * Time.deltaTime;

        Vector3 _move = new Vector3(movementVector.x, movementVector.y * Time.deltaTime, movementVector.z);
        controller.Move(_move); //controller.Move(movementVector);
    }

    public void Jump()
    {
        if (controller.isGrounded)
            movementVector.y = Mathf.Sqrt(JUMP_HEIGHT * jumpForce * G_CONSTANT);
    }
*/
