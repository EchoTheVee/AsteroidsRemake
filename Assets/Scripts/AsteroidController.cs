using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private float scale;
    private int rotate;
    private Rigidbody asteroidRb;
    private float xTarg;
    private float zTarg;
    public float moveForce;
    public GameObject asteroidPrefab;
    private int numberOfTimes = 2;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        asteroidRb = GetComponent<Rigidbody>();
        scale = Random.Range(0.3f, 0.5f);
        rotate = Random.Range(5, 360);
        transform.rotation = Quaternion.Euler(new Vector3(rotate, rotate, rotate));
        transform.localScale = new Vector3(scale, scale, scale);
        xTarg = Random.Range(-10, 10);
        zTarg = Random.Range(-7, 7);
        asteroidRb.AddForce(new Vector3(xTarg, 0, zTarg) * moveForce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            gm.AddScore(50);
            SpawnPrefab(numberOfTimes);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    public void SpawnPrefab(int numberOfTimes)
    {
        Instantiate(asteroidPrefab, transform.position, asteroidPrefab.transform.rotation);
        rotate = Random.Range(5, 360);
        asteroidPrefab.transform.rotation = Quaternion.Euler(new Vector3(rotate, rotate, rotate));
        asteroidPrefab.transform.localScale = new Vector3(scale/2, scale/2, scale/2);
    }
}
