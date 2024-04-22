using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class BallController : MonoBehaviour
{

    [SerializeField]
    private GameObject particle;
   // [SerializeField]
    
    Rigidbody rb;
    bool started;
    bool gameOver;
    public float speed;

    private BallController Instance;



    private void Awake()
    {   if(Instance == null)
        {
            Instance = this;
        }
        rb = gameObject.GetComponent<Rigidbody>();

    }

    // Start is called before the first frame update  
    void Start()
    {
        started = false;
        gameOver = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

                GameManager.Instance.StartGame();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            switchDirection();
        }

        if (isGameOver())
        {
            print("Game Over");
        }

    }

    void switchDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }


    }

    bool isGameOver()
    {
        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);
            Camera.main.GetComponent<CameraController>().gameOver = gameOver;

            GameManager.Instance.GameOver();
        }
        return gameOver;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Diamond"))
        {
            GameObject temp = Instantiate(particle, other.gameObject.transform.position, Quaternion.identity);     
            Destroy(other.gameObject);
            ScoreManager.Instance.IncrementScrore();
            Destroy(temp, 1f);

        }
    }
}
