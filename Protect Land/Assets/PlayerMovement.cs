using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float speed = 5f;
    public float runspeed = 12f;
    //bool isRunning = false;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Animator animator;
    int sideStep = Animator.StringToHash("Side Step");
    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

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

        //START THE ANIMATION WHIKLE WALKING
        if(Input.GetKey(KeyCode.W)){
            animator.SetInteger("condition", 1);
        }
         if(Input.GetKeyUp(KeyCode.W)){
            animator.SetInteger("condition", 0);
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
         if(Input.GetKey(KeyCode.A)){
            animator.SetTrigger(sideStep);
            
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
