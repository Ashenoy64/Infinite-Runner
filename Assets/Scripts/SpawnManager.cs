using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefab;
    public float delay = 1.0f;
    public float interval = 1.50f;
    public Vector3 spawnPos;
    private PlayerController playerControllerScript;
    void Start()
    {
        InvokeRepeating("spawnObstacle", delay, interval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void spawnObstacle()
    {
        
        if(playerControllerScript.gameOver == false)
        Instantiate(prefab, new Vector3(30, -0.3f, 0), prefab.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
