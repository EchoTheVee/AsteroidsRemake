using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private float scale;
    private int rotate;
    private Rigidbody asteroidRb;
    // Start is called before the first frame update
    void Start()
    {
        asteroidRb = GetComponent<Rigidbody>();
        scale = Random.Range(0.1f, 0.5f);
        rotate = Random.Range(5, 360);
        transform.rotation = Quaternion.Euler(new Vector3(rotate, rotate, rotate));
        transform.localScale = new Vector3(scale, scale, scale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
