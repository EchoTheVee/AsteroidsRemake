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
    private GameManager gm;
    public GameObject thruster;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up * turnSpeed * horizontalInput * Time.deltaTime);
        playerRb.AddRelativeForce(Vector3.forward * moveSpeed * verticalInput);

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectilePrefab, spawnerPrefab.transform.position, transform.rotation);
        }

        if (verticalInput >= 0.1f)
        {
            thruster.SetActive(true);
        }

        else
        {
            thruster.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gm.hp = gm.hp - 1;
        }
    }
}
