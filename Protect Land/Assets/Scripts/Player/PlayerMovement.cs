using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float speed = 5f;
    public float runspeed = 12f;
    //bool isRunning = false;
    Rigidbody rb;

    //public Transform camTransform;
    public float shakeDuration = 0f;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    Vector3 originalPos;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
       
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        if(z > 0){
            //animator.SetFloat("InputZ", z);
        }
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * runspeed * Time.deltaTime);
        }

        //camera shake walk effect
        if(Input.GetKeyDown(KeyCode.W))
        {
            
        }
       /* if(Input.GetButtonDown("Jump") && isGrounded)
        {
           velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        } */

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
    
    }
