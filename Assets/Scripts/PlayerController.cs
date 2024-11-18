using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float verticalInput;
    private float horizontalInput;
    public float turnSpeed;
    public float moveSpeed;
    private Rigidbody playerRb;
    public GameObject projectilePrefab;
    public GameObject spawnerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up * turnSpeed * horizontalInput * Time.deltaTime);
        playerRb.AddRelativeForce(Vector3.forward * moveSpeed * verticalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, spawnerPrefab.transform.position, transform.rotation);
        }
    }
}
