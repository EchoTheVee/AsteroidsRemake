using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMiniController : MonoBehaviour
{
    private float scale;
    private int rotate;
    private Rigidbody asteroidRb;
    private float xTarg;
    private float zTarg;
    public float moveForce;
    public GameManager gm;
    private AudioSource audioSource;
    private AudioClip onHit;
    //public GameObject asteroidPrefab;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("GameManager").GetComponent<AudioSource>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        asteroidRb = GetComponent<Rigidbody>();
        scale = Random.Range(0.1f, 0.27f);
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
            audioSource.PlayOneShot(gm.onHit, 1.0f);
            gm.AddScore(25);
            //SpawnPrefab();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    public void SpawnPrefab()
    {
        //Instantiate(asteroidPrefab, transform.position, asteroidPrefab.transform.rotation);
       //rotate = Random.Range(5, 360);
        //asteroidPrefab.transform.rotation = Quaternion.Euler(new Vector3(rotate, rotate, rotate));
        //asteroidPrefab.transform.localScale = new Vector3(scale/2, scale/2, scale/2);
    }
}
