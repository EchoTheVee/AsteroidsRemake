using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float xRange;
    public float zRange;

    public GameObject asteroidPrefab;

    public int waveSize = 3;
    //public Slider waveSizeSlider;
    //public TextMeshProUGUI waveSizeDisplay;

    // Start is called before the first frame update
    void Start()
    {
        //waveSizeSlider.value = waveSize;
        InvokeRepeating("SpawnPrefab", 3, 3);
    }

    // Update is called once per frame
    void Update()
    {


      /*  if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SpawnPrefab();
        }*/
    }

    public Vector2 RandomPosition()
    {
        float xPosition = Random.Range(-xRange, xRange);
        float zPosition = Random.Range(-zRange, zRange);
        Vector2 randomPos = new Vector3(xPosition, 1, zPosition);
        return randomPos;
    }

    public void SpawnPrefab()
    {
        Instantiate(asteroidPrefab, RandomPosition(), transform.rotation);
    }

    public void SpawnWave()
    {
        for (int i = 0; i < waveSize; i++)
        {
            SpawnPrefab();
        }
    }

    public void UpdateWaveSize()
    {
        //waveSize = (int)waveSizeSlider.value;
        //waveSizeDisplay.text = waveSize.ToString();
    }
}
