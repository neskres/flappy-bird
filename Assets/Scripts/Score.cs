using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Zenject;

public class Score : MonoBehaviour
{
    public static Score instance;

    public Image medalImage;
    public Image bonusImage;

    [SerializeField] private GameObject _bonusGameObject;

    [SerializeField] private Sprite yellowMedalImage;
    [SerializeField] private Sprite blueMedalImage;
    [SerializeField] private Sprite redMedalImage;

    [SerializeField] private TextMeshProUGUI _bonusName;
    [SerializeField] private TextMeshProUGUI _currentScoreTextRate;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    [SerializeField] private TextMeshProUGUI _highScoreRateText;

    private Sprite _sprite;
    private int _score;
    private string _name;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        _currentScoreTextRate.text = _score.ToString();

        _highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        _highScoreRateText.text = _highScoreText.text;

        UpdateHighScore();
    }

    public void UpdateHighScore()
    {
        if (_score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", _score);
            _highScoreText.text = _score.ToString();
        }    
    }

    public void UpdateScore(int scoreAdd)
    {
        _score += scoreAdd;
        _currentScoreTextRate.text = _score.ToString();
        UpdateHighScore();
        UpdateMedal();
    }

    public void ShowBonusName(string _nameData)
    {
        _name = _nameData;
        _bonusName.text = _name;
    }
    public void ShowBonusSprite(Sprite _spriteBonus)
    {
        _bonusGameObject.SetActive(true);
        _sprite = _spriteBonus;
        bonusImage.sprite = _sprite;
    }

    private void FixedUpdate()
    {
        UpdateMedal();
    }

    public void UpdateMedal()
    {
        if (_score <= 5000 )
        {
            medalImage.sprite = yellowMedalImage;
        } 
        else if (_score > 5000 && _score <= 10000)
        {
            medalImage.sprite = blueMedalImage;
        } 
        else
        {
            medalImage.sprite = redMedalImage;
        }
    }
}
