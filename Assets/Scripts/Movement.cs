using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;


public class Movement : MonoBehaviour
{
    // Making Movement again
    public float speed = 10f;
    public float health = 100f;
    public float jumpforce = 7f;
    public float dashSpeed = 5f;
    public float dashDuration = 0.2f;
    public LayerMask groundLayer; // a Layer mask is used to help specify which layer you want to collide with 
    private bool isGrounded;
    private bool isDashing = false;
    private float dashTime;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {



        MovementFunction(); // Calling player Movement here
        AnimationFunction();
        HandleDash();
        Jump();
        Debug.Log("isGrounded: " + isGrounded);
    }

    void AnimationFunction()
    {
        bool isWalking = Mathf.Abs(rb.linearVelocity.x) > 0.1f; // check if moving happens, if it does then trigger walking animation (basically is the velocity more than 0.1f if so walk)

        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isGrounded", isGrounded);

    }
    void MovementFunction()
    {

        float moveX = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
        }

        if (moveX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveX), 1f, 1f);
        }

        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

       if ((( 1 << collision.gameObject.layer) & groundLayer) !=0)
        {
            isGrounded = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = false;

        }
    }
        void HandleDash()
        {

            if (isDashing)
            {
                dashTime -= Time.deltaTime;
                if (dashTime <= 0)
                {
                    isDashing = false;
                    rb.linearVelocity = Vector2.zero;
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
            {
                StartDash();

            }
        }

        void StartDash()
        {
            isDashing = true;
            dashTime = dashDuration;

            float direction = Input.GetKey(KeyCode.A) ? -1 : 1;
            rb.linearVelocity = new Vector2(direction * dashSpeed, 0f);
        }

        void Jump()
        {

            if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpforce);
            }
        }
    }



