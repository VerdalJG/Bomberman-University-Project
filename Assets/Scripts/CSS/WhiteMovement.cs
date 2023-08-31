﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteMovement : MonoBehaviour
{
    //Animator reference
    public Animator whiteAnimator;
    //Rigidbody name for reference
    private Rigidbody2D whiterb;
    //Parameters for movement speed and direction
    private Vector2 moveVelocity;
    private float speed = 20f;

    //Delay for movement
    private bool inputEnabled = true;

    //Variable to determine direction for animation and movement
    [HideInInspector] public float sideMovement;

    //Reference to center position
    Vector3 centerPosition = new Vector3(0, -1, 0);

    //Variables to control movement and confirm
    private bool IsCentered = false;
    private bool FinalConfirm = false;

    void Start()
    {
        //Reference the rigidbody
        whiterb = GetComponent<Rigidbody2D>();
        whiteAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!IsCentered)
        {
            //Stop the character in the center from right
            if (transform.position.x < centerPosition.x && sideMovement == -1)
            {
                //Stop movement
                moveVelocity = moveVelocity * 0;
                //Enable input
                inputEnabled = true;
                //Center game object
                transform.position = centerPosition;
                IsCentered = true;
                sideMovement = 0;
                whiteAnimator.SetBool("Moving", false);
                whiteAnimator.SetFloat("Horizontal", sideMovement);
            }

            //Stop the character in the center from left
            if (transform.position.x > centerPosition.x && sideMovement == 1)
            {
                //Stop movement
                moveVelocity = moveVelocity * 0;
                //Enable input
                inputEnabled = true;
                //Center gameobject
                transform.position = centerPosition;
                IsCentered = true;
                sideMovement = 0;
                whiteAnimator.SetBool("Moving", false);
                whiteAnimator.SetFloat("Horizontal", sideMovement);
            }
        }

        if (inputEnabled)
        {
            //Input direction of movement for ANIMATION
            sideMovement = Input.GetAxisRaw("Horizontal");
            if (sideMovement != 0)
            {
                //Movement Vector
                Vector2 moveInput = new Vector2(sideMovement, 0);
                //Multiply direction of movement with speed
                moveVelocity = moveInput.normalized * speed;
                //Set value in animator's parameter for transition in animation
                whiteAnimator.SetFloat("Horizontal", sideMovement);
                //Disable Input until rotation complete
                inputEnabled = false;
                //Animation control based on input
                whiteAnimator.SetBool("Moving", true);
            }


            //Confirm input
            float confirmInput = Input.GetAxisRaw("Confirm");

            //Confirm player selection
            if (confirmInput == 1 && !FinalConfirm)
            {
                //Trigger animation for confirm
                whiteAnimator.SetTrigger("Confirm");
                FinalConfirm = true;
            }
        }

        //Move the character to the right to out of the screen
        if (transform.position.x < 11 && sideMovement == 1)
        {
            whiterb.MovePosition(whiterb.position + moveVelocity * Time.fixedDeltaTime);
        }
        //Move the character to the left to out of the screen
        if (transform.position.x > -11 && sideMovement == -1)
        {
            whiterb.MovePosition(whiterb.position + moveVelocity * Time.fixedDeltaTime);
        }
        //Reset moveDirection back to 0 once offscreen and destroy once offscreen
        if (transform.position.x > 11 | transform.position.x < -11)
        {
            Destroy(gameObject);
        }
    }
}
