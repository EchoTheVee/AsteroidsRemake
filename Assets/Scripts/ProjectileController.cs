using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Rigidbody projectileRb;
    public float projectileSpeed;
    public float waitInSeconds;
    // Start is called before the first frame update
    void Start()
    {
        projectileRb = GetComponent<Rigidbody>();
        projectileRb.AddRelativeForce(Vector3.forward * projectileSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, waitInSeconds);
    }
}
