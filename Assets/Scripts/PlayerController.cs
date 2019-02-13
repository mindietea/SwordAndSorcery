using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float turnSpeed = 60.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController charController;

    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // is the controller on the ground?
        if (charController.isGrounded)
        {
            float turn = Input.GetAxis("Horizontal");
            transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);

            //Feed moveDirection with input.
            moveDirection = transform.forward * Input.GetAxis("Vertical") * moveSpeed;

            //Jumping
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }

        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move
        charController.Move(moveDirection * Time.deltaTime);

    }
}
