using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AVClub.Bases;

namespace AVClub
{
    public class Player : BaseEntity
    {
        private const float P_SPEED_NORMAL = 300f;
        private const float P_SPEED_SLOWED = 185f;
        private const float P_FRICTION = 0.2f;
        private const float P_DASH_INI_TIMER = 5f;
        private const float P_DASH_IMPULSE = 300f;
        private const float JUMP_HEIGHT = 3f;

        public float jumpForce = -2f;
        public float turnSpeed = 1f;
        public Transform visualizer;
        public bool isInteracting = false;
        private Quaternion targetRotation;
        private float speed;
        private float currentSpeed;
        [SerializeField] private float dashCooldown = 0f;

        [Header("Last facing: required for DASH")]
        /*[SerializeField]*/
        private float lastFacing;                           //-1 for left and 1 for right.

        [Header("MeleeAttack variables")]
        private Ray ray;
        private RaycastHit hit;

        protected override void Start()
        {
            startHits = 6;
            visualizer.rotation = Quaternion.Euler(0f, -90f, 0f);
            lastFacing = 1;
            base.Start();

            InputManager.jumpInput += Jump;
            InputManager.dashInput += Dash;
            InputManager.leftInput += HorizontalInput;
            InputManager.rightInput += HorizontalInput;
            InputManager.downInput_Down += EnableInteract;
            InputManager.downInput_Up += DisableInteract;
            InputManager.attackInput += MeleeAttack;
            InputManager.altFireInput += RangedAttack;
        }

        protected override void Update()
        {
            base.Update();

            visualizer.rotation = Quaternion.Lerp(visualizer.rotation, targetRotation, turnSpeed * Time.deltaTime);

            //Initiating and resetting the dash cooldown timer.
            if (dashCooldown > 0f) dashCooldown -= Time.deltaTime;
            if (dashCooldown <= 0f) dashCooldown = 0f;
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

        public void Dash()
        {
            if (dashCooldown == 0f)
            {
                dashCooldown = P_DASH_INI_TIMER;
                Vector3 test;
                test.x = lastFacing * P_DASH_IMPULSE * Time.deltaTime;
                movementVector.x += test.x;
            }
        }

        public void HorizontalInput()
        {
            //TEMPORARY WORK AROUND. CODE NEEDS FURTHER REVIEWING.
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                lastFacing = -1;
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                lastFacing = 1;

            targetRotation = Quaternion.Euler(0f, -90f * lastFacing, 0f);           //Causing some sort of UnityEngine error. REQUIRES A REVIEW.
        }

        public void MeleeAttack()
        {
            if (Physics.Raycast(visualizer.position, -visualizer.forward, out hit))
            {
                BaseEntity _entity = hit.transform.GetComponent<BaseEntity>();
                _entity.Damage(1);
            }
        }

        public void RangedAttack()
        {
            //Add logic here.
        }

        //There has to be a better way to set "isInteracting". THIS CODE AND THE ONE IN InputManager NEEDS A REVIEW.
        public void EnableInteract() => isInteracting = true;
        public void DisableInteract() => isInteracting = false;

        public override void ApplyEffects()
        {
            base.ApplyEffects();

            currentSpeed = isSlowed ? P_SPEED_SLOWED : P_SPEED_NORMAL;                      //The SLOWNESS effect.
        }
    }
}
