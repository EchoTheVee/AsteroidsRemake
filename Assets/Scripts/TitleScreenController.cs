using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    private void Start()
    {
        //PlayerPrefs.GetInt("highScore");
        //PlayerPrefs.SetInt("highScore", 10);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("LoadingScreen");
        }
    }
}
