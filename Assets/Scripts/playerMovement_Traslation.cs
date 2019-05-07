using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement_Traslation : MonoBehaviour
{

    public float speed;
    public float basicSpeed  = 10;
    public bool moving;

    public bool right;
    public bool left;
    public bool center;

    public Vector3 distancia = new Vector3(3,0,0);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Movement();

    }

    void Movement()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        transform.Translate(Vector3.forward * basicSpeed * Time.deltaTime);


        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right + distancia);
 
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left - distancia);
        }

        if (Input.GetAxisRaw("Horizontal") != 0.0f | Input.GetAxisRaw("Vertical") != 0.0f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }


    }
}
