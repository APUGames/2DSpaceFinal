using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // This script will handle the game's state

    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private GameObject playerScoreText;
    [SerializeField]
    private GameObject playerWonText;
    [SerializeField]
    private int playerWinPoints;

    private bool playerWon = false;
    private bool playerDead = false;

    private int playerPoints = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetHealth() <= 0)
        {
            playerDead = true;
        }

        if (playerPoints > playerWinPoints)
        {
            playerWon = true;
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        playerScoreText.GetComponent<Text>().text = $"{playerPoints}/{playerWinPoints}";

        if (playerWon)
        {
            playerWonText.SetActive(true);
        }
        else
        {
            playerWonText.SetActive(false);
        }
    }

    public void SetPlayerPoints(int points)
    {
        playerPoints += points;
    }

    public void SetPlayerWon(bool won)
    {
        playerWon = won;
    }

    public bool GetPlayerDead()
    {
        return playerDead;
    }

    public bool GetPlayerWon()
    {
        return playerWon;
    }

    public GameOverScreen GameOverScreen;
    int maxPlatform = 0;

    public void GameOver()
    {
        GameOverScreen.Setup(maxPlatform);
    }

    
}
