using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject gameOverPanel;
    public GameObject zigzagPanel;
    public TextMeshProUGUI tapText;
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore1;
    public TextMeshProUGUI highScore2;



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
        highScore1.text = "High Score: " + PlayerPrefs.GetInt("highestScore");
    }

    public void GameStart()
    {
        
        tapText.gameObject.SetActive(false);
        zigzagPanel.gameObject.GetComponent<Animator>().Play("panelUp");
    }

    public void GameOver()
    {
        gameOverPanel.gameObject.SetActive(true);
        score.text = PlayerPrefs.GetInt("score").ToString();

        highScore1.text = "High Score: " + PlayerPrefs.GetInt("highestScore").ToString();
        highScore2.text = PlayerPrefs.GetInt("highestScore").ToString();

    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
