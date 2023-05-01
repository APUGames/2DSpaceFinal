using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    // This script will manage to the timer UI text
    public int startTime;

    private float currentTime;
    private float nextCurrentTime;
    private float intervalTime = 1.0f;
    private float baseIntervalTime = 0f;

    private Text timerText;

    private int trackTime;

    private bool isPlaying = true;

    // Start is called before the first frame update
    void Start()
    {
        timerText = gameObject.GetComponent<Text>();
        timerText.text = startTime.ToString();
        currentTime = (float)startTime;
        trackTime = startTime;
        // nextCurrentTime = currentTime - 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            if (baseIntervalTime < intervalTime)
            {
                baseIntervalTime += Time.deltaTime;
            }
            else
            {
                currentTime -= intervalTime;
                trackTime = (int)currentTime;
                timerText.text = trackTime.ToString();
                // nextCurrentTime = currentTime - 1.0f;
                baseIntervalTime = 0f;
            }

            // Check if trackTime is zero and
            // if zero tell game that player won
            if (trackTime == 0)
            {
                // Do something
                isPlaying = false;
                GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
                if (gameManager != null)
                {
                    gameManager.SetPlayerWon(true);
                }
            }
        }
    }
}