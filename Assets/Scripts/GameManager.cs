using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI healthDisplay;
    public TextMeshProUGUI highScoreDisplay;
    public int hp = 3;
    public GameObject player;
    public AudioClip onHit;
    private int highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        highScoreDisplay.text = $"HighScore: {highScore}";

        score = 0;
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        //highScore = PlayerPrefs.GetInt("highScore");

        healthDisplay.text = $"Health: {hp}";

        if (hp <= 0)
        {
            SceneManager.LoadScene("GameOverScreen");
        }
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
}
