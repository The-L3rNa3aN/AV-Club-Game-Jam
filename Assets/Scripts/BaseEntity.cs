using UnityEngine;

//Base class which will be inherited by the player and NPC classes.

[RequireComponent(typeof(CharacterController))]
public class BaseEntity : MonoBehaviour
{
    protected const float G_CONSTANT = -20f;

    protected Vector3 movementVector;
    protected CharacterController controller;
    
    public virtual void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MoveEntity();
    }

    public virtual void MoveEntity()
    {
        if(controller.isGrounded && movementVector.y < 0f)
            movementVector.y = -2f;

        movementVector.y += G_CONSTANT * Time.deltaTime;

        Vector3 _move = new Vector3(movementVector.x, movementVector.y * Time.deltaTime, movementVector.z);
        controller.Move(_move);
    }
}
