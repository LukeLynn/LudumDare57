using UnityEditor.Rendering;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D body;

    public float speed;
    public float drag;

    public bool grounded;

    public b

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        if (Mathf.Abs(xInput) > 0)
        {
            body.linearVelocity = new Vector2(xInput * speed, body.linearVelocity.y);
        }

        if (Mathf.Abs(yInput) > 0)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, yInput * speed);
        }


        
        //Vector2 direction = new Vector2(xInput, yInput).normalized;
        //body.linearVelocity = direction * speed;
    }


    private void FixedUpdate()
    {
        CheckGround();

        if (grounded)
        {
            body.linearVelocity *= drag;
        }
    }


    void CheckGround()
    {

    }









}


