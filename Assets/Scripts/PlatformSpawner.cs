using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject diamond;
    Vector3 lastPos;
    float size;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
        //because both x and z have the same scale so it'll work for both
        size = transform.localScale.x;


        for (int i = 0; i < 30; i++)
        {   //call 0 and 1 bcause 0 -> < 2
            PlatformSpawning();
        } 
    }

    public void StartSpawningPlatforms()
    {
        InvokeRepeating("PlatformSpawning", 2f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance._GameOver)
        {
            CancelInvoke("PlatformSpawning");
        }
    }

    void PlatformSpawning()
    {   //return 0 -> 9 => 10 numbers
        int spawnDiamond = Random.Range(0, 10);
        //return 0 -> 1 => 2 numbers
        int spawnPlatform = Random.Range(0, 2);
        if (spawnPlatform == 0)
        {
            SpawnX();
        }
        if (spawnPlatform == 1)
        {
            SpawnZ();
        }

        if (spawnDiamond < 1)
        {
            //because this will be call after SpawnX and SpawnZ method, which will update the lastPos
            //so that lastPost will be updated
            Vector3 diamondPos = new Vector3(lastPos.x, lastPos.y + 1f, lastPos.z);
            Instantiate(diamond, diamondPos, diamond.transform.rotation);
        }

    }


    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);
    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);
    }
}
