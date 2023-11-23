using System.Collections;
using UnityEngine;

//Base class which will be inherited by the player and NPC classes.

[RequireComponent(typeof(CharacterController))]
public class BaseEntity : MonoBehaviour, HealthSystem
{
    protected const float G_CONSTANT = -20f;

    public int hitsLeft;
    public int startHits;
    protected Vector3 movementVector;
    protected CharacterController controller;

    [Header("Entity Effects")]
    public bool isSlowed;                       //Slows down the entity.
    public bool markedForDeath;                 //Instantly kills the entity after a period of time.
    public bool isBurning;                      //Sets the entity on fire, dealing damage over time.
    public bool isCursed;                       //Enables the entity to give and take double damage.

    [Header("Marked-for-death variables")]
    protected float mfdTimer;
    protected const float EFFECT_MFD_INI_TIME = 20f;

    [Header("Burn variables")]
    [SerializeField] protected float burnTimer = 0f;
    [SerializeField] protected int burnTick = 0;
    protected const float EFFECT_BURN_INI_TIME = 30f;
    
    protected virtual void Start()
    {
        controller = GetComponent<CharacterController>();
        mfdTimer = EFFECT_MFD_INI_TIME;
        //burnTimer = EFFECT_BURN_INI_TIME;

        StartHealth(startHits);
    }

    protected virtual void Update()
    {
        MoveEntity();
        ApplyEffects();
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
    public void RestoreHealth() => StartHealth(startHits);

    public virtual void Heal(int number) => hitsLeft += number;

    public virtual void Damage(int number)
    {
        int n = isCursed ? number * 2 : number;                     //Curse: deal twice the damage at the cost of being twice more vulnerable.
        hitsLeft -= n;

        if(hitsLeft <= 0)
            Kill();
    }

    public virtual void Kill() => gameObject.SetActive(false);

    public void ClearEffects()
    {
        isSlowed = false;
        markedForDeath = false;
        isBurning = false;
        isCursed = false;
    }

    public void ResetBurnTimer() => burnTimer = EFFECT_BURN_INI_TIME;

    public virtual void ApplyEffects()
    {
        //Marked for Death: the entity will be instantly killed upon the timer running out.
        if (markedForDeath)
            mfdTimer -= Time.deltaTime;
        else
            mfdTimer = EFFECT_MFD_INI_TIME;

        if(mfdTimer <= 0f)
        {
            mfdTimer = 0f;
            Kill();
        }

        //Burn: name says it all. Deals 1 Damage point every 10 seconds for a period of 30 seconds.
        if(isBurning)
        {
            burnTimer += Time.deltaTime;

            if (burnTick < 3)
            {
                if(burnTimer >= 10f)
                {
                    burnTimer = 0f;
                    burnTick++;
                    Damage(1);
                }
            }
            else
            {
                isBurning = false;
                burnTimer = 0f;
                burnTick = 0;
            }
        }
    }
}
