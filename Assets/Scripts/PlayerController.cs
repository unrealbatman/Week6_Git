using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

    private CharacterController characterController;

    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isHover;
    public float floatingAmplitude = 0.1f; // Adjust this value to control the floating height
    public float floatingFrequency = 2f;  // Adjust this value to control the speed of the floating motion
    public float jumpForce;

    Vector3 velocity;

    public bool isGrounded;
    public static bool isMoving;

    private Vector3 lastPosition = new Vector3(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //GroundCheck
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        //Resetting the default velocity
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //calculate move direction , right is red line, forward is blue (from editor)
        Vector3 move = transform.right * x + transform.forward * z;


        characterController.Move(speed * Time.deltaTime * move);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            //actually jumping
            if (isHover)
            {
                velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);

            }
            else
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            }
        }

        //falling down
        if (isHover)
        {
           velocity.y += (gravity * Time.deltaTime * floatingFrequency) * floatingAmplitude  ;
            if (gameObject.transform.position.y > 90)
            {
                velocity.y += gravity * Time.deltaTime;
            }
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;

        }

        //executing the jump
        characterController.Move(velocity * Time.deltaTime);

   

        if(Input.GetButtonDown("Jump") &&  !isGrounded) 
        {
            isHover = false;
        }
        if(lastPosition != gameObject.transform.position && isGrounded == true)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        lastPosition = gameObject.transform.position;
    
        if(PublicVars.score >= 40){
            SceneManager.LoadScene("WinScreen");
        }
    }

  
}
