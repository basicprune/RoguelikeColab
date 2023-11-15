using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovementController : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private Camera camera;
    [SerializeField] private float cameraSensitivity;
    [SerializeField] private float lookXLimit = 45f;


    private Vector3 moveDir = Vector3.zero;
    private float xRot = 0f;


    private bool canMove = true;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        //lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        //check sprint
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float currentSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxisRaw("Vertical") : 0f;
        float currentSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxisRaw("Horizontal") : 0f;

        float movementDirY = moveDir.y;
        moveDir = (forward * currentSpeedX) + (right * currentSpeedY);

        if (Input.GetButton("Jump") && canMove && controller.isGrounded)
        {
            moveDir.y = jumpSpeed;
        }
        else
        {
            moveDir.y = movementDirY;
        }

        //gravity
        if(!controller.isGrounded)
        {
            moveDir.y -= gravity * Time.deltaTime;
        }

        //movement
        controller.Move(moveDir * Time.deltaTime);

        //camera and rotation
        if (canMove)
        {
            xRot += -Input.GetAxis("Mouse Y") * cameraSensitivity;
            xRot = Mathf.Clamp(xRot, -lookXLimit, lookXLimit);
            camera.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * cameraSensitivity, 0);
        }
    }
}
