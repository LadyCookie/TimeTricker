﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverDisplay;

    public float delayRestart;
    public float delayDisplayRound;

    public bool gameHasEnded;
    public bool gameHasWon;

    private string menuSceneName = "Menu";

    private void Start()
    {
        gameHasEnded = false;
        gameHasWon = false;
    }
    private void Awake()
    {
        Time.timeScale = 1f; //disactivation of pause
        gameOverDisplay.SetActive(false);
    }
    private void Update()
    {
        if (gameHasWon)
        {
            WinGame();
        }
        if (gameHasEnded)
        {
            EndGame();
        }

        //return to main menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(menuSceneName);// SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
    public void EndGame()
    {
        Debug.Log("------ Game Over -------");
        gameOverDisplay.SetActive(true);

        Invoke("GameOver", 0);
        Invoke("GoHighscoreMenu", delayRestart);
    }

    public void WinGame()
    {
        Debug.Log("------ Win -------");
        gameOverDisplay.SetActive(true);

        Invoke("NextRound", delayDisplayRound);
        Invoke("Restart", delayRestart);
    }

    void GoHighscoreMenu()
    {
        SceneManager.LoadScene("EndGameMenu");
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void NextRound()
    {
        gameOverDisplay.GetComponentInChildren<Text>().text = "You survived! Well played";
        gameOverDisplay.GetComponentInChildren<Text>().fontSize = 30;
        gameOverDisplay.GetComponentInChildren<Text>().color = Color.green;
    }

    void GameOver()
    {
        gameOverDisplay.GetComponentInChildren<Text>().text = "Game Over";
        gameOverDisplay.GetComponentInChildren<Text>().color = Color.red;
    }
}
