using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour
{

    AudioSource audioData;
    public GameObject Score;
    public GameObject BestScore;
    public float timer = 0.0f;
    float bestS = 0.0f;
    public bool end = true;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        bestS = StoreScore.GetBestScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (end)
        {
            timer += Time.deltaTime;
            Score.GetComponent<TextMeshProUGUI>().text = ((int)timer).ToString();
            BestScore.GetComponent<TextMeshProUGUI>().text = ((int)bestS).ToString();
            if (bestS < timer)
            {
                bestS = timer;
                StoreScore.SetBestScore((int)bestS);
                BestScore.GetComponent<TextMeshProUGUI>().text = ((int)bestS).ToString();
            }
        }
        else
        {
            Player.GetComponent<playerMovement_Traslation>().moving = true;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }

        }

    }
  
}
public static class StoreScore
{
    public static int BestScore;
    
    public static int GetBestScore()
    {
        return BestScore;
    }
    public static void SetBestScore(int BestT)
    {
        BestScore = BestT;
    }

}
