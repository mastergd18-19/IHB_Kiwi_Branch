using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    #region VARIABLES
    public float speed = 0;
    public float deceleration = 0.25f;
    public float acceleration = 1f;
    float maxSpeed = 5;
    float lateral;
    float forward;
    Rigidbody rb;
    Vector3 vel;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Speed: " + speed);
        //rb.velocity = vel;
        Acceleration();
        //accelerationFunction();
        Movement();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
            //Acceleration();
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
           // Acceleration();

        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -speed);
            //Acceleration();

        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
            //Acceleration();

        }

    }
    /*void accelerationFunction()
    {
        forward = Input.GetAxis("Forward");
        lateral = Input.GetAxis("Lateral");


        vel.x = Mathf.Clamp(-speed, speed, maxSpeed);

    }*/
    void Acceleration()
    {
        forward = Input.GetAxis("Forward");
        lateral = Input.GetAxis("Lateral");
        if (forward != 0 || lateral != 0)
        {
            if (speed < maxSpeed)
            {
                speed += acceleration * Time.deltaTime;
                speed = Mathf.Clamp(speed,0,maxSpeed);
            }

        }
        else
        {
            if (speed > 0)
            {
                speed -= acceleration;
                speed = Mathf.Clamp(speed, 0, maxSpeed);

            }
            else
            {
                rb.velocity = vel;
            }
        }


    }

}
