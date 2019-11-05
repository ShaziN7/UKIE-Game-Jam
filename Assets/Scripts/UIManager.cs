using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _p1ScoreText;
    [SerializeField]
    private Text _p2ScoreText;
    [SerializeField]
    private Text _timerText;
    [SerializeField]
    private float _timeLeft = 60.0f;

    private GameManager _gameManager; // Reference to the Game Manager


    // Start is called before the first frame update
    void Start()
    {
        _p1ScoreText.text = "Player 1 Score: " + 0;
        _p2ScoreText.text = "Player 2 Score: " + 0;
        _timerText.text = "Time Left: ";

        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();

        if (_gameManager == null)
        {
            Debug.LogError("Game Manager is NULL.");
        }
    }


    private void Update()
    {
        UpdateTimer();
    }


    public void UpdateScore(int playerScore, int playerNumber)
    {
        if (playerNumber == 1)
        {
            _p1ScoreText.text = "Score: " + playerScore;
        }

        else if (playerNumber == 2)
        {
            _p2ScoreText.text = "Score: " + playerScore;
        }
    }


    public void UpdateTimer()
    {
        _timeLeft -= Time.deltaTime;

        if (_timeLeft > 0)
        {
            _timerText.text = "Time Left: " + (_timeLeft).ToString("0") + "s";
        }

        else
        {
            // End game
        }
    }

    public void GameOverSequence()
    {
        // Do game over things here

        _gameManager.GameOver();
    }
}