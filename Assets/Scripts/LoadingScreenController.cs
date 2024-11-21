using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenController : MonoBehaviour
{
    public Slider loadBar;
    // Start is called before the first frame update
    void Start()
    {
        loadBar.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        loadBar.value += 0.1f;

        if (loadBar.value >= 100)
        {
            SceneManager.LoadScene("MainLevel");
        }
    }
}
