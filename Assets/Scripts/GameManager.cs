using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

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
    public Camera main;
    public Slider colorSlider;
    public MeshRenderer mr;
    public Material[] colors;
    public int colorValue;

    // Start is called before the first frame update
    void Start()
    {
        colorSlider.value = PlayerPrefs.GetInt("colorValue");
        mr = GameObject.Find("PlayerMR").GetComponent<MeshRenderer>();
        highScore = PlayerPrefs.GetInt("highScore");
        highScoreDisplay.text = $"HighScore: {highScore}";
        score = 0;
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        highScore = PlayerPrefs.GetInt("highScore");

        healthDisplay.text = $"Health: {hp}";

        if (hp <= 0)
        {
            SceneManager.LoadScene("GameOverScreen");
        }
        mr.material = colors[Mathf.RoundToInt(colorSlider.value)];
        /*
        if (colorSlider.value == 1)
        {
            mr.material = purple;
        }

        if (colorSlider.value == 2)
        {
            mr.material = yellow;
        }
*/

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
