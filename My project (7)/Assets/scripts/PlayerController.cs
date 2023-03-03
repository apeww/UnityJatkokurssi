using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10f;
    public float rotationSpeed = 200f;
    public float jumpForce = 400f;

    public TextMeshProUGUI pointsText;


    int points = 0;

    Rigidbody rb;
    Vector3 playerInput;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {

        Vector3 rotation = transform.up * Input.GetAxis("Horizontal");
        transform.Rotate(rotation * rotationSpeed * Time.deltaTime);
        playerInput = transform.forward * Input.GetAxis("Vertical") * speed;

        playerInput.y = rb.velocity.y;


        if (rb.velocity.y > -0.05f && rb.velocity.y < 0.05f)
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {

                rb.AddForce(Vector3.up * jumpForce);
            }
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = playerInput;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectable")
        {
            Destroy(other.gameObject);
            points++;
            pointsText.text = "Points: " + points;
            if (points >= 4)
            {
                pointsText.text = "Voitit Pelin";
            }
        }
    }
}
