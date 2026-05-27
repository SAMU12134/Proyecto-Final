using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Referencias")]
    public Camera playerCamera;
    [Header("General")]
    public float gravityScale = -20f;

    [Header("Movement")]
    public float WalkSpeed= 5f;
    public float RunSpeed= 7.4f;


    [Header("Jump")]
    public float JumpHeight = 1.9f;

    [Header("Rotacion")]
    public float rotationSensibility = 10f;
    


    
    


    private float cameraVerticalAngle;


    Vector3 moveInput = Vector3.zero;
    Vector3 RotationInput = Vector3.zero;
    CharacterController characterController;


    private void Start()
    {



        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();

    }

    private void Update() 
    {


        Move();
        Look();

    }

    private void Move ()
    {   
        if(characterController.isGrounded)
        {
            moveInput = new Vector3(Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical"));
            moveInput = Vector3.ClampMagnitude(moveInput,1f);


             if(Input.GetButton("Sprint"))
             {
                moveInput = transform.TransformDirection(moveInput)*RunSpeed;


             }
             else
             {


                moveInput = transform.TransformDirection(moveInput)*WalkSpeed;
             }

            if (Input.GetButtonDown("Jump"))
            {


                moveInput.y = Mathf.Sqrt(JumpHeight * -2f * gravityScale);
            }




        }
        

        
        moveInput.y += gravityScale * Time.deltaTime;
        characterController.Move(moveInput*Time.deltaTime);
    }
    
    

    
    private void Look()
    {

        RotationInput.x = Input.GetAxis("Mouse X") * rotationSensibility * Time.deltaTime;
        RotationInput.y = Input.GetAxis("Mouse Y") * rotationSensibility * Time.deltaTime;

        cameraVerticalAngle += RotationInput.y;
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -70, 70);

        transform.Rotate(Vector3.up * RotationInput.x);
        playerCamera.transform.localRotation = Quaternion.Euler(-cameraVerticalAngle, 0f, 0f);

    }

        
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
}
