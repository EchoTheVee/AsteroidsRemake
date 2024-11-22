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
    public int hp = 3;
    public GameObject player;
    public AudioClip onHit;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = $"Health: {hp}";

        if (hp <= 0)
        {
            SceneManager.LoadScene("GameOverScreen");
        }
    }

    public void UpdateScore()
    {
        scoreDisplay.text = $"Score: {score}";
    }

    public void AddScore(int amountToAdd)
    {
        score += amountToAdd;
        UpdateScore();
    }
}
