using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrecursedController : MonoBehaviour
{
    public Animator animator;

    CharacterController characterController;


    // Movement Variables
    public float speed = 10.0f;
    public float rotSpeed = 100.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;



    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    IEnumerator MoveCharacter()
    {
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)))
            {
                animator.SetBool("Run", true);
            }
            else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                animator.SetBool("Run", false);
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;
        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MoveCharacter());

    }
}
