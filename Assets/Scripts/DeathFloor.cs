using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathFloor : MonoBehaviour
{
    public GameObject player;

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
        //Si el jugador colisiona muiere al momento
        if (collision.gameObject.name == "PlayerMesh")
        {
            Destroy(collision.gameObject);
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
