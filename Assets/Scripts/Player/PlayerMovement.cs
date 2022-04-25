using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 5f;
    public float gravity = -30f;
    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;
    bool isGrounded;
    Vector3 velocity;
    public float jumpHeight = 3;
    public float jumpCounter = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            jumpCounter = 1;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter <= 2)
        {
            jumpCounter ++;
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        if(jumpCounter > 2 && isGrounded)
        {
            jumpCounter = 1;
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            speed = 9f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5f;
        }
        /*if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }*/
        characterController.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
