using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0;
    public float gravity = -9.81f;

    private CharacterController controller;

    Vector3 velocity;
    

    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    
    void FixedUpdate()
    {
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;


        controller.Move(move * moveSpeed * Time.deltaTime);

        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
    }
}
