using System;
using UnityEngine;

//Base class which will be inherited by the player and NPC classes.

[RequireComponent(typeof(CharacterController))]
public class BaseEntity : MonoBehaviour
{
    // private const float MAX_ACCEL = 100f;
    // private const float P_SPEED = 10f;
    // private const float P_FRICTION = 0.2f;
    private const float G_CONSTANT = -20f;
    // private const float JUMP_HEIGHT = 3f;

    // private float speed;
    private Vector3 movementVector;
    private CharacterController controller;
    
    private void Start()
    {
        controller = GetComponent<Controller>();
    }

    private void Update()
    {
    }

    private void MoveEntity()
    {
        if(controller.isGrounded && movementVector.y < 0f)
            movementVector.y = -2f;

        movementVector.y += G_CONSTANT * Time.deltaTime;
        controller.Move(movementVector);
    }
}
