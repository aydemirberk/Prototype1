using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] private int horsePower = 0;

    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float rpm;

    private Rigidbody playerRb;
    private float turnSpeed = 40;

    private float horizontalInput;
    private float verticalInput;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            //print Rpm
            rpm = Mathf.Round(speed % 30) * 40;
            rpmText.SetText("Rpm: " + rpm);

            //print Speed
            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);
            speedometerText.SetText("Speed:" + speed + "Km/ph");

            // We move the vehicle
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            //Rotate the vehicle
            playerRb.AddRelativeForce(Vector3.forward * verticalInput * horsePower);
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        }

        
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }

        }
        if (wheelsOnGround == 4)
        {
                return true;
        }
        else
        {
                return false;
        }
        
    }




}
