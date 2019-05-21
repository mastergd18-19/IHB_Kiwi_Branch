using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement_Traslation : MonoBehaviour
{

    public float speed;
    public float basicSpeed  = 10;
    public bool moving;

    public bool right = false;
    public bool left = false;
    public bool center = false;
    public bool rightMovement = false;
    public bool leftMovement = false;
    public float count = 10;

    Animator Anim;

    public Vector3 distancia = new Vector3(30,0,0);


    // Start is called before the first frame update
    void Start()
    {
        center = true;
        Anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {

        Movement();

    }

    public void Movement()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * basicSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D) && moving==false && right==false)
        {
            rightMovement = true;

            for (count = 1; count >=0; count =(count - 0.1f * Time.deltaTime))
            {
                //Debug.Log("TEST COUNT = " + count);
            }
            Debug.Log("TEST COUNT = " + count);

            if (count <= 0)
            {
                count = 1;
                if (center)
                {
                    //transform.Translate(Vector3.right + distancia);
                    //transform.position = Vector3.Lerp(transform.position,transform.position + distancia, 1 * Time.deltaTime);

                    center = false;
                    right = true;

                }
                else if (left)
                {
                    //transform.Translate(Vector3.right + distancia);

                    center = true;
                    left = false;

                }
            }
           
            
        }

        if (Input.GetKey(KeyCode.A) && moving == false && left==false)
        {
            leftMovement = true;

            for (count = 1; count >= 0; count = (count - 0.1f * Time.deltaTime))
            {
                //Debug.Log("TEST COUNT = " + count);
            }

            if (count==0)
            {

            }
            if (center)
            {
                //transform.Translate(Vector3.left - distancia);

                center = false;
                left = true;
            }
            else if (right)
            {
                //transform.Translate(Vector3.left - distancia);

                center = true;
                right = false;
            }

        }

        if (Input.GetAxisRaw("Horizontal") != 0.0f | Input.GetAxisRaw("Vertical") != 0.0f)
        {
            moving = true;
        }
        else
        {
            rightMovement = false;
            leftMovement = false;
            moving = false;
        }


    }
}
