using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Score")]
    public int score;
    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI healthDisplay;
    public TextMeshProUGUI highScoreDisplay;
    private int highScore;

    [Header("Player")]
    public GameObject player;
    public int hp = 3;
    public AudioClip onHit;

    [Header("Colors")]
    public Material[] colors;
    public int colorValue;
    public MeshRenderer mr;
    public Slider colorSlider;

    [Header("Extras")]
    public Camera main;

    void Start()
    {
        colorSlider.value = PlayerPrefs.GetInt("colorValue");
        mr = GameObject.Find("PlayerMR").GetComponent<MeshRenderer>();
        highScore = PlayerPrefs.GetInt("highScore");
        highScoreDisplay.text = $"HighScore: {highScore}";
        score = 0;
        UpdateScore();
    }

    void Update()
    {
        highScore = PlayerPrefs.GetInt("highScore");

        healthDisplay.text = $"Health: {hp}";

        if (hp <= 0)
        {
            SceneManager.LoadScene("GameOverScreen");
        }
        mr.material = colors[Mathf.RoundToInt(colorSlider.value)];
    }

    public void UpdateScore()
    {
        if (score >= highScore)
        {
            highScore = score;
        }
        PlayerPrefs.SetInt("highScore", highScore);

        scoreDisplay.text = $"Score: {score}";
        highScoreDisplay.text = $"HighScore: {highScore}";
    }

    public void AddScore(int amountToAdd)
    {
        score += amountToAdd;
        UpdateScore();
    }

    public void ColorValueUpdate()
    {
        colorValue = (int) colorSlider.value;
        
        PlayerPrefs.SetInt("colorValue", colorValue);
    }
}
