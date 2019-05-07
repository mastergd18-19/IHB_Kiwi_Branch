using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement_physics : MonoBehaviour
{


    private Rigidbody rb;
    public float acceleration;
    public float deceleration;
    public bool moving;

    public float t;
    public float rR;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("CheckSpeed", t, rR);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        Movement();
        MovementDeceleration();

    }


    void Movement()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetAxis("Horizontal") != 0.0f | Input.GetAxis("Vertical") != 0.0f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * acceleration);

    }

    void MovementDeceleration()
    {

        if (moving == false)
        {
            rb.angularDrag = deceleration;
        }
        else
        {
            rb.angularDrag = 0.05f;
        }

    }
    void CheckSpeed()
    {

        Debug.Log("Velocidad en x: " + rb.velocity.x);
        Debug.Log("Velocidad en y: " + rb.velocity.y);
        Debug.Log("Velocidad en z: " + rb.velocity.z);

    }

}
