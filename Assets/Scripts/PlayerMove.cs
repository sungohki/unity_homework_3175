using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Variables
    Rigidbody rb;
    [SerializeField] private float speed = 15.0f;
    [SerializeField] private float addSpeed = 1.3f;
    [SerializeField] private float jump = 5.0f;
    
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
     }

    // Update is called once per frame
    void Update()
    {
        Walking();
        Jumping();
    }
    void Jumping()
    {
        if (Input.GetKey(KeyCode.Space)) {
            transform.Translate(Vector3.up * Time.deltaTime * jump);
        }
    }

    void Walking() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);

        movement.Normalize();
        movement *= speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftShift))
            movement *= addSpeed;


        transform.Translate(movement);
    }
}
