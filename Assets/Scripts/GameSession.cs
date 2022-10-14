using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] private int playerLives = 3;
    [SerializeField] private int score = 0;
    [SerializeField] private Text lifeText;
    [SerializeField] private Text scoreText;
    
    void Awake()
    {
        int count = FindObjectsOfType<GameSession>().Length;
        if (count > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        lifeText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
            TakeLife();
        else
            Reset();
    }

    private void TakeLife()
    {
        --playerLives;
        lifeText.text = playerLives.ToString();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
    
    void Reset()
    {
        SceneManager.LoadScene(0);

        playerLives = 3;
        score = 0;
        
        lifeText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

}
