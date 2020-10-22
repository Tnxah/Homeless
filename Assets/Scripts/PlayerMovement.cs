using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;


    private CharacterController controller;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask grountMask;

    bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, grountMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;


        controller.Move(move * moveSpeed * Time.deltaTime);

        //Jumping
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }



        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        
    }
}
