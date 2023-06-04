using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenicRotation : MonoBehaviour
{
    public float rotationSpeedX = 3f;
    public float rotationSpeedY = 3f;

    void Update()
    {
        // Rotate the object
        transform.Rotate(Vector3.right, rotationSpeedX * Time.deltaTime); // X
        transform.Rotate(Vector3.up, rotationSpeedY * Time.deltaTime); // Y
    }
}

