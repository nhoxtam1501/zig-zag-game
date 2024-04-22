using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool _GameOver;

    public int FPS = 60;

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
        _GameOver = false;
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = FPS;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        UIManager.Instance.GameStart();
        //ScoreManager.Instance.StartScore();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawningPlatforms();
        print( "Type of object: " + FindObjectOfType<PlatformSpawner>());
    }

    public void GameOver()
    {
        UIManager.Instance.GameOver();
        ScoreManager.Instance.StopScore();
        _GameOver = true;
    }

    public void IncrementVelocityOverTime()
    {
        var ball = GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>();
        
    }
}
