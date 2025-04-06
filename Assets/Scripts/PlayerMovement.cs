using UnityEditor.Rendering;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D body;

    public float groundSpeed;
    public float jumpSpeed;
    public float acceleration;

    [Range(0f, 1f)]

    public float groundDecay;

    public bool grounded;

    public BoxCollider2D groundCheck;
    public LayerMask groundMask;

    float xInput;
    float yInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        HandleJump();
        


        //Vector2 direction = new Vector2(xInput, yInput).normalized;
        //body.linearVelocity = direction * speed;
    }

    void FixedUpdate()
    {
        CheckGround();
        MoveWithInput();
        ApplyFriction();
    }
    void GetInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }

    void MoveWithInput()
    {

        if (Mathf.Abs(xInput) > 0)
        {
            float increment = xInput * acceleration;
            float newSpeed = Mathf.Clamp(body.linearVelocityX + increment, -groundSpeed, groundSpeed);

            body.linearVelocity = new Vector2(newSpeed, body.linearVelocityY);
            float direction = Mathf.Sign(xInput);
            transform.localScale = new Vector3(direction, 1, 1);
        }

    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            body.linearVelocity = new Vector2(body.linearVelocityX, jumpSpeed);
        }
    }

    void CheckGround()
    {
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
    }

    void ApplyFriction()
    {
        if (grounded && xInput == 0 && body.linearVelocityY == 0)
        {
            body.linearVelocity *= groundDecay;
        }
    }







}


