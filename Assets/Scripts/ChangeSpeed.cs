using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeed : MonoBehaviour
{

    public float NewSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Comprobamos si es el jugador el que colisiona con el suelos
        if (collision.gameObject.name == "PlayerMesh")
        {
            //Cambiamos la velocidad del jugador
            collision.transform.parent.GetComponent<playerMovement_Traslation>().basicSpeed = NewSpeed;
        }
    }

}
