using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement_Traslation : MonoBehaviour
{

    public float speed;
    public float basicSpeed  = 10f;
    public bool moving;

    public bool right = false;
    public bool left = false;
    public bool center = false;
    public bool rightMovement = false;
    public bool leftMovement = false;
    public float count = 10f;
    private bool AnimReady = true;

    Animator Anim;

    public Vector3 distancia = new Vector3(3,0,0);


    // Start is called before the first frame update
    void Start()
    {
        center = true;
        Anim = this.gameObject.GetComponentInParent<Animator>();
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
        //Debug.Log("TEST1 = " + AnimReady);


        if (Input.GetKeyDown(KeyCode.D) && moving==false && right==false && AnimReady)
        {
            rightMovement = true;
            AnimReady = false;

            count = 1;
            if (center)
            {
                //Debug.Log("TEST1 = " + Anim.GetCurrentAnimatorStateInfo(0).IsName("p_Left-Center"));

                //transform.Translate(Vector3.right + distancia);
                Anim.Play("p_Right");
                StartCoroutine(executeAfterTime(0.45f));

                //transform.position = Vector3.Lerp(transform.position,transform.position + distancia, 1 * Time.deltaTime);

                center = false;
                right = true;

            }
            else if (left)
            {
                //transform.Translate(Vector3.right + distancia);
                Anim.Play("p_Left-Center");
                StartCoroutine(executeAfterTime(0.45f));

                center = true;
                    left = false;

                }           
            
        }

        if (Input.GetKeyDown(KeyCode.A) && moving == false && left==false && AnimReady)
        {
            leftMovement = true;
            AnimReady = false;

            if (center)
            {
                //transform.Translate(Vector3.left - distancia);
                Anim.Play("p_Left");
                StartCoroutine(executeAfterTime(0.45f));

                center = false;
                left = true;
            }
            else if (right)
            {
                //transform.Translate(Vector3.left - distancia);
                Anim.Play("p_Right-Center");
                StartCoroutine(executeAfterTime(0.45f));

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

    IEnumerator executeAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        AnimReady = true;
    }

}
