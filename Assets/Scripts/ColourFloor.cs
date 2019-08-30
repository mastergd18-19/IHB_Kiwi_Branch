using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColourFloor : MonoBehaviour
{

    public enum m_colour 
    {
        Blue,
        Yellow
    }
    public m_colour AssignedColour;
    public Material M_Yellow;
    public Material M_Blue;
    GameObject Manager;
    bool onTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("GameManager");
        //Comprobamos el color que le hemos asigando desde el editor y se lo colocamos
        if (AssignedColour == m_colour.Blue)
        {
            this.transform.parent.GetComponent<Renderer>().material = M_Blue;
        }
        else
        {
            this.transform.parent.GetComponent<Renderer>().material = M_Yellow;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (onTrigger)
        {
            Manager.GetComponent<Manager>().timer += Time.deltaTime*2;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Comprobamos si es el jugador el que colisiona con el suelos
        if (collision.gameObject.name == "PlayerMesh")
        {
            onTrigger = true;

            //Cuando el jugador entra comprobamos si usa el color que esta colocado e el suelo si no coincide lo matamos
            if (!collision.gameObject.GetComponent<Renderer>().material.name.Contains(AssignedColour.ToString()))
            {
                Destroy(collision.gameObject);
                Application.LoadLevel(Application.loadedLevel);
            }            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "PlayerMesh")
        {
            onTrigger = false;
        }
    }
}
