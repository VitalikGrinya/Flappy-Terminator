using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Plane _plane;
    [SerializeField] private EnemiesGenerator _enemiesGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;

    private void OnEnable()
    {
        _startScreen.PlayButtonCliked += OnPlayButtonClick;
        _endScreen.RestartButtonClick += OnRestartButtonClicked;
        _plane.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonCliked -= OnPlayButtonClick;
        _endScreen.RestartButtonClick -= OnRestartButtonClicked;
        _plane.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _endScreen.Open();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClicked()
    {
        _endScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _plane.Reset();
    }
}
