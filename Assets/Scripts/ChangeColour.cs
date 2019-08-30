using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{


    public enum m_colour
    {
        Blue,
        Yellow
    }
    public m_colour Playercolour;
    public Material M_Yellow;
    public Material M_Blue;


    // Start is called before the first frame update
    void Start()
    {
        //Por defecto el cubo se inicia en amarillo
        Playercolour = m_colour.Yellow;
        this.GetComponent<Renderer>().material = M_Yellow;
    }

    // Update is called once per frame
    void Update()
    {
        changeColour();
    }

    private void changeColour()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Playercolour == m_colour.Blue)
            {
                //Cambiamos el color del cubo
                this.GetComponent<Renderer>().material = M_Yellow;
                //Activamos y desactivamos la colisión para prevenir que el jugador cambie de color mientras se encuentra en una calle, ya que uso OnCollisionEnter
                this.GetComponent<SphereCollider>().enabled = false;
                this.GetComponent<SphereCollider>().enabled = true;
                Playercolour = m_colour.Yellow;
            }
            else
            {
                //Cambiamos el color del cubo
                this.GetComponent<Renderer>().material = M_Blue;
                //Activamos y desactivamos la colisión para prevenir que el jugador cambie de color mientras se encuentra en una calle, ya que uso OnCollisionEnter
                this.GetComponent<SphereCollider>().enabled = false;
                this.GetComponent<SphereCollider>().enabled = true;
                Playercolour = m_colour.Blue;
            }
        }


    }

}
