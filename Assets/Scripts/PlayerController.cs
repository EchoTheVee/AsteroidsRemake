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
    public Camera main;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (verticalInput < 0)
        {
            verticalInput = 0;
        }

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
            main.fieldOfView = 55;
            StartCoroutine(fovChangeOnHit());
            gm.hp = gm.hp - 1;
            //main.fieldOfView = 60;
        }
    }

    IEnumerator fovChangeOnHit()
    {
        yield return new WaitForSeconds(0.2f);
        main.fieldOfView = 60;
    }
}
