using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;
    public float horizontalInput;
    public Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // get the user's horizontal input
        horizontalInput = Input.GetAxis("Horizontal");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * Time.deltaTime * speed * horizontalInput);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right, rotationSpeed * verticalInput * -1 * Time.deltaTime);
    }
}
