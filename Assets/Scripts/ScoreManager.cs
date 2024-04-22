using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score;
    public int highestScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncrementScrore()
    {
        score += 1;
    }

    public void StartScore()
    {
        InvokeRepeating("IncrementScore", 0.1f, 0.5f);
    }

    public void StopScore()
    {
      
        PlayerPrefs.SetInt("score", score);

        if (PlayerPrefs.HasKey("highestScore"))
        {
            highestScore = PlayerPrefs.GetInt("highestScore");
            if (score > highestScore)
            {
                highestScore = score;
                PlayerPrefs.SetInt("highestScore", highestScore);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highestScore", highestScore);
        }

    }
}
