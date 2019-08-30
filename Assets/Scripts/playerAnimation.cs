using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimation : MonoBehaviour
{

    playerMovement_Traslation pm;
    Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
       pm = this.gameObject.GetComponent<playerMovement_Traslation>();
       Anim = this.gameObject.GetComponentInParent<Animator>();
       Anim.SetBool("Center", true);


    }

    // Update is called once per frame
    void Update()
    {

        if (pm.rightMovement)
        {
            Debug.Log("TEST center = " + pm.center);

            if (Anim.GetBool("Center"))
            {
                Anim.Play("p_Right");
                //Anim.SetBool("Right", true);
                //Anim.SetBool("Center", false);
                Debug.Log("TEST1 Left = " + Anim.GetBool("Left"));
                Debug.Log("TEST1 Center = " + Anim.GetBool("Center"));
                Debug.Log("TEST1 Right = " + Anim.GetBool("Right"));


            }
            else if (pm.left)
            {
                Anim.SetBool("Left", false);
                Anim.SetBool("Center", pm.center);
            }
            
        }

        if (pm.leftMovement)
        {
            if (Anim.GetBool("Center"))
            {
                Anim.SetBool("Center", false);
                Anim.SetBool("Left", true);
            }
            else if(Anim.GetBool("Right"))
            {
                Anim.SetBool("Center",true);
                Anim.SetBool("Right", false);
                Debug.Log("TEST2 Left = " + Anim.GetBool("Left"));
                Debug.Log("TEST2 Center = " + Anim.GetBool("Center"));
                Debug.Log("TEST2 Right = " + Anim.GetBool("Right"));
            }

        }

        if (!pm.moving)
        {
            Anim.SetBool("Idle", true);
        }
        else
        {
            Anim.SetBool("Idle", false);
        }

    }
}
