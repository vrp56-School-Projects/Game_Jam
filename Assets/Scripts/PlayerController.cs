using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    CharacterController characterController;


    // Movement Variables
    public float speed = 6.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;

    [SerializeField]
    private float _movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("Run", true);
            if (characterController.isGrounded)
            {
                // We are grounded, so recalculate
                // move direction directly from axes

                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
                moveDirection *= speed;
            }
            // Move the controller
            characterController.Move(moveDirection * Time.deltaTime);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("Run", false);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Attack");
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;



    }
}
