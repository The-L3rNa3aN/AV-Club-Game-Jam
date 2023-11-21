using UnityEngine;

//Base class which will be inherited by the player and NPC classes.

[RequireComponent(typeof(CharacterController))]
public class BaseEntity : MonoBehaviour
{
    protected const float G_CONSTANT = -20f;

    public int hitsLeft = 10;
    public int startHits = 10;
    protected Vector3 movementVector;
    protected CharacterController controller;
    
    public virtual void Start()
    {
        controller = GetComponent<CharacterController>();

        StartHealth(startHits);
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

    public virtual void StartHealth(int number) => hitsLeft = startHits;

    public virtual void Heal(int number) => hitsLeft += number;

    public virtual void Damage(int number)
    {
        hitsLeft -= number;

        if(hitsLeft <= 0)
            Kill();
    }

    public virtual void Kill() => gameObject.SetActive(false);
}
