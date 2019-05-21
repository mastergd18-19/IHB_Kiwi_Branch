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

            if (pm.center)
            {
                Debug.Log("TEST COUNT = " + pm.right);
                Anim.SetBool("Right", pm.right);
                Anim.SetBool("Center", pm.center);
            }
            else if (pm.left)
            {
                Anim.SetBool("Right", pm.right);
                Anim.SetBool("Center", pm.center);
            }
            
        }

        if (pm.leftMovement)
        {
            if (pm.center)
            {
                Anim.SetBool("Center", pm.center);
                Anim.SetBool("Left", pm.left);
            }
            else if(pm.right)
            {
                Anim.SetBool("Center", pm.center);
                Anim.SetBool("Left", pm.left);
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
