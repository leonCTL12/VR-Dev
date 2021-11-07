using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCPlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float gravity = -9.81f;

    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float groundDistance;
    [SerializeField]
    private LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if(isGrounded && velocity.y < 0) //velocity.y < 0 = still falling
        {
            velocity.y = -2f; //work better, coz maybe player is ground but still dropping.
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; //create direction to move base on where player is facing

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime; 
        controller.Move(velocity * Time.deltaTime); //multiply Time.deltaTime once more because d = 1/2*g*t^2
    }
}
