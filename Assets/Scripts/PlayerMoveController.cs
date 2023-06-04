using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The PlayerController handles input relative to the player's movement
/// </summary>
public class PlayerMoveController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Rigidbody playerRB;
    private Vector3 moveInput;
    
    // Ship movement
    private float acceleration = 5f; // The acceleration factor
    private Vector3 currentVelocity; // The current velocity of the spaceship

    // Ship rolling
    public float rollAcceleration = 10f; // The roll acceleration factor
    public float maxRollAngle = 90f; // The maximum roll angle in degrees
    private float currentRollAngle; // The current roll angle


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.z = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        // Calculate the target velocity based on moveInput and moveSpeed
        Vector3 targetVelocity = moveInput * moveSpeed;

        // Interpolate the current velocity towards the target velocity using acceleration
        currentVelocity = Vector3.Lerp(currentVelocity, targetVelocity, Time.deltaTime * acceleration);

        // Apply the velocity to the rigidbody
        playerRB.velocity = currentVelocity;

        // Calculate the target roll angle based on the horizontal movement
        float targetRollAngle = -moveInput.x * maxRollAngle;

        // Interpolate the current roll angle towards the target roll angle using acceleration
        currentRollAngle = Mathf.Lerp(currentRollAngle, targetRollAngle, Time.deltaTime * rollAcceleration);

        // Create a rotation quaternion for the roll angle
        Quaternion rollRotation = Quaternion.Euler(0f, 0f, currentRollAngle);

        // Apply the rotation to the spaceship
        transform.rotation = rollRotation;
    }
}
