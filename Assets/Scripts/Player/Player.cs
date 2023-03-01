using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;

    public CharacterController characterController;
    public float speed = 1f;
    public float turnSpeed = 1f;
    public float gravity = 9.8f;
    public float jumpForce = 100;

    public float runSpeed = 1.5f;


    private float vSpeed = 0f;
    private float verticalAxis;
    private float horizontalAxis;

    private void Start()
    {
       
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        verticalAxis = Input.GetAxis("Vertical");
        horizontalAxis = Input.GetAxis("Horizontal");

        transform.Rotate(0, horizontalAxis * turnSpeed, 0);
        var speedVector = speed * verticalAxis * transform.forward;

        if(characterController.isGrounded)
        {
            vSpeed = 0;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                vSpeed = jumpForce;
            }
        }

        var isWalking = verticalAxis != 0;
        if(isWalking)
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                speedVector *= runSpeed;
                animator.speed = runSpeed;
            }
            else
            {
                animator.speed = 1f;
            }
        }
        vSpeed -= gravity * Time.deltaTime;

        speedVector.y = vSpeed;

        characterController.Move(speedVector * Time.deltaTime);

        animator.SetBool("Run", isWalking);
    }
}
