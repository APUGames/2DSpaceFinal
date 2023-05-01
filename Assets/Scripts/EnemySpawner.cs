using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public string debugName;

    public Vector3[] spawnPoints;

    [SerializeField]
    private float queueTime = 2.0f;
    private float currentQueueTime;

    [SerializeField]
    private float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentQueueTime = queueTime;
    }

    // Update is called once per frame
    void Update()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (currentQueueTime < 0f)
        {
            // Debug.Log(debugName + " " + transform.position);
            int spawnLocationIndex = Random.Range(0, spawnPoints.Length);
            Vector3 spawnLocation = spawnPoints[spawnLocationIndex];
            GameObject enemy = Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);
            enemy.GetComponent<EnemyController>().SetSpeed(speed);
            currentQueueTime = queueTime;
        }
        else
        {
            currentQueueTime -= Time.deltaTime;
        }
    }

    int numberOfEnemies = 10;

    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }
}