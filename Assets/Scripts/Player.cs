using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private const float MAX_ACCEL = 100f;
    private const float P_SPEED = 10f;
    private const float P_FRICTION = 0.2f;
    private const float G_CONSTANT = -20f;
    private const float JUMP_HEIGHT = 3f;

    [SerializeField] private int hitCount;
    private float speed;
    private Vector3 movementVector;
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        /*InputManager.leftInput += MoveLeft;
        InputManager.rightInput += MoveRight;*/
    }

    private void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        speed = hor * P_SPEED * Time.deltaTime;

        if(speed > MAX_ACCEL) speed = MAX_ACCEL;

        if (controller.isGrounded && movementVector.y < 0f)
            movementVector.y = -2f;

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
            movementVector.y = Mathf.Sqrt(JUMP_HEIGHT * -2f * G_CONSTANT);

        movementVector.x += speed * Time.deltaTime;
        movementVector.x -= P_FRICTION * movementVector.x;
        movementVector.y += G_CONSTANT * Time.deltaTime;

        controller.Move(movementVector);
    }

    /*private void MoveLeft()
    {
        
    }

    private void MoveRight()
    {

    }*/
}
