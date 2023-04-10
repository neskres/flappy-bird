using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Canvas")]
    [SerializeField] private GameObject _startGameCanvas;
    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private GameObject _levelCanvas;
    [Header("Panel")]
    [SerializeField] private GameObject _soundPanel;
    [SerializeField] private GameObject _ratePanel;
    [SerializeField] private GameObject _pausePanel;
    [Header("Gameplay")]
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _itemsSpawner;
    [SerializeField] private GameObject _pauseButton;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        _pauseButton.SetActive(false);
        _gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PauseOn()
    {   
        _pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void MenuButtonPressed()
    {
        SceneManager.LoadScene("SampleScene");
        _levelCanvas.SetActive(false);
        _startGameCanvas.SetActive(true);
        _gameOverCanvas.SetActive(false);
        _player.SetActive(false);
        _itemsSpawner.SetActive(false);
    }

    public void ContinueButtonPressed()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void StartGame()
    {
        _startGameCanvas.SetActive(false);
        _gameOverCanvas.SetActive(false);
        _player.SetActive(true);
        _itemsSpawner.SetActive(true);
        _levelCanvas.SetActive(true);
    }

    public void SoundSettingsPressed()
    {
        _soundPanel.SetActive(true);
    }

    public void OkButtonPressed()
    {
        _soundPanel.SetActive(false);
    }

    public void RateButtonPressed()
    {
        _ratePanel.SetActive(true);
    }
    public void RateButtonOk()
    {
        _ratePanel.SetActive(false);
    }
}
