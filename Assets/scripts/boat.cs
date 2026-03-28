using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boat : MonoBehaviour
{
    /*public float speed = 10f;
    public float turnSpeed = 50f;

    
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * move * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
    }*/
    private Rigidbody rb;
    //public float speed = 20f;
    public float turnSpeed = 50f;
    public float acceleration = 20f;
    public float maxSpeed = 20f;
    public float startcountdown = 3f;
    private bool canMove = false;


    public float currentSpeed = 0f;
    private int startTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(vertical != 0)
        {
            currentSpeed = Mathf.Clamp(currentSpeed + vertical * acceleration * Time.fixedDeltaTime, -maxSpeed, maxSpeed);

        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, 0.1f);
        }

        Vector3 moveDirection = -transform.right * currentSpeed;
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);

        if (currentSpeed != 0)
        {
            float turn = horizontal * turnSpeed * Time.fixedDeltaTime;
            Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
            rb.MoveRotation(rb.rotation * turnRotation);
        }

        if (startTimer <= 0)
        {
            canMove = true;
        }

        if (startTimer < 3)
        {
            canMove = false;
        }
    }
}
