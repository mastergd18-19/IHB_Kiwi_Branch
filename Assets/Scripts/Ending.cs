using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{

    public GameObject EndingCanvas;
    public GameObject GameManager;

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
        //Comprobamos si es el jugador el que colisiona con el trigger final
        if (collision.gameObject.name == "PlayerMesh")
        {
            //Cargar widget de victoria
            EndingCanvas.SetActive(true);
            //CORUTINA PARA HACER FADEOUT DEL VOLUMEN
            StartCoroutine(FadeOut(GameManager.GetComponent<AudioSource>(), 6f));
            GameManager.GetComponent<Manager>().end = false;
        }
    }
    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

}
