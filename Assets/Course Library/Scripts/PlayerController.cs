using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class PlayerController : MonoBehaviour
{
    protected Rigidbody playerRB;
    protected float speed = 0;
    protected float rpm = 0;
    private float _horsePower = 25000;
    protected const float turnSpeed = 30.0f;

    [SerializeField] protected GameObject centerOfMass;
    [SerializeField] protected TextMeshProUGUI speedometerText;
    [SerializeField] protected TextMeshProUGUI RPMText;
    [SerializeField] protected TextMeshProUGUI UserName;
    [SerializeField] protected List<WheelCollider> allWheels;
    protected int wheelsOnGround = 0;

    protected float HorsePower
    {
        get { return _horsePower; }
    }


    protected abstract void Move(float horizontalInput, float verticalInput);

    protected void UpdateSpeedAndRPM()
    {
        speed = Mathf.RoundToInt(playerRB.velocity.magnitude * 2.237f);
        speedometerText.SetText("Speed: " + speed + "mph");

        rpm = Mathf.Round((speed % 30) * 40);
        RPMText.SetText("RPM: " + rpm);

        UserName.SetText("User: "+GameManager.instance.userName);
    }


    protected bool IsOnGround()
    {
        wheelsOnGround = 0;

        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        return wheelsOnGround == allWheels.Count;
    }
}
