using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Car : PlayerController
{
    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerRB.centerOfMass = centerOfMass.transform.position;
    }

    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            Move(horizontalInput, verticalInput);
            UpdateSpeedAndRPM();
            transform.Rotate(Vector3.up * turnSpeed * horizontalInput * Time.deltaTime);
        }
    }

    // POLYMORPHISM
    protected override void Move(float horizontalInput, float verticalInput)
    {
        playerRB.AddRelativeForce(Vector3.forward * HorsePower * verticalInput);
    }
}