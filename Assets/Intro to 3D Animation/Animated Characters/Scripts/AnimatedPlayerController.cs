using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedPlayerController : MonoBehaviour
{
    public GameObject playerModel;

    //Movement Variables
    private float verticalInput;
    public float moveSpeed;

    private float horizontalInput;
    public float turnSpeed;

    //Shoot Variables
    public KeyCode attackKey;

    //Crouch Variable
    public KeyCode crouchKey;
    public bool isCrouching = false;

    //Jumping Variables
    public KeyCode jumpKey;
    private Rigidbody rb;
    public float jumpForce;
    public bool isOnGround;

    Animation Variables;
    public Animator animator;

    //Particles
    public ParticleSystem dustCloud;


    // Start is called before the first frame update
    void Start()
    {
        //Get Components
        rb = GetComponent<Rigidbody>();
       animator = playerModel.GetComponent<Animator>();
        dustCloud.Stop();


    }

    // Update is called once per frame
    void Update()
    {
        //Forward and Backward Movement
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * verticalInput);

        //Activate or Deactivate Running
        animator.SetFloat("verticalInput",Mathf.Abs(verticalInput));

        //Activate Dust Cloud

        if(verticalInput>0 && !dustCloud.isPlaying)
        {
            dustCloud.Play();
        }
        else if(verticalInput <= 0)
        { 
            dustCloud.Stop(); 
        }

        //Rotation
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);

        //Jumping
        if(Input.GetKeyDown(KeyCode.Space)  && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            animator.SetBool("isOnGround", isOnGround);
        }

        //Crouch
        if (Input.GetKey(crouchKey))
        {
            isCrouching = true;
        }
        else
        {
            isCrouching = false;
        }
        animator.SetBool("isCrouching", isCrouching);

        //Attack
        if(Input.GetKeyDown(attackKey))
        {
           animator.SetTrigger("attack");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            animator.SetBool("isOnGround", isOnGround);
        }
    }
}
