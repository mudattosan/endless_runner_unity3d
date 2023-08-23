using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlller : MonoBehaviour
{
    public float slideLength;
    private CharacterController controller;
    private Animator animator;
    private BoxCollider boxCollider;
    private Vector3 playerVelocity;
    private bool groundedPlayer = false;
    private bool isSliding = false;

    private float jumpHeight = 4.0f;
    private float gravityValue = -9.81f;

    public float moveSpeed;
    public float leftRightSpeed;
    private float slideStart;
    private Vector3 boxColliderSize;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        boxColliderSize = boxCollider.size;
    }

    void Update()
    {

        controller.Move(Vector3.forward * Time.deltaTime * moveSpeed);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > LevelBuondary.leftSide)
            {
                controller.Move(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < LevelBuondary.rightSide)
            {
                controller.Move(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
            }
        }

        RaycastHit hit;
        if(Physics.Raycast(transform.position, -transform.up, out hit, 3f))
        {
            groundedPlayer = true;
        } else
        {
            groundedPlayer = false;
        }

        if (groundedPlayer && playerVelocity.y <= 0f)
        {
            playerVelocity.y = 0f;
            
        }

       

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
           playerVelocity.y += Mathf.Sqrt(jumpHeight * -0.3f * gravityValue);
            animator.SetBool("Jump", true);
            
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity);
        // animation
        if (playerVelocity.y > 0f && !groundedPlayer)
        {
            animator.SetBool("Spin", true);
            animator.SetBool("Run", false);
            animator.SetBool("Jump", false);
        }
        else
        {
            animator.SetBool("Run", true);
            animator.SetBool("Spin", false);
        }
        // slide
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Slide();
        }

        if (isSliding)
        {
            float ratio = (transform.position.z - slideStart) / slideLength;
            
            if(ratio >= 1f)
            {
                isSliding = false;
                animator.SetBool("Slide", false);
                boxColliderSize = boxCollider.size;
                controller.height = 1.8f;
                controller.center = new Vector3(0, 0.9f, 0);
            }
        }
       
        void Slide()
        {
            slideStart = transform.position.z;
            animator.SetBool("Slide", true);
            // xu ly boxCollider
            Vector3 newSize = boxCollider.size;
            Vector3 newCenter = boxCollider.center;
            newSize.y = newSize.y / 2;
            newCenter.y = newSize.y / 2;
            boxCollider.size = newSize;
            boxCollider.center = newCenter;
            // xu ly characterController
            controller.height = 0.9f;
            controller.center = new Vector3(0, 0.45f, 0);
            isSliding = true;
        }
        ;

    }
}
