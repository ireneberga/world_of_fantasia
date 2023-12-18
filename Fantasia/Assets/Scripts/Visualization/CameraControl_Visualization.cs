using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl_Visualization : MonoBehaviour
{
    public float rotationSpeed = 2f;
    public float maxLookUpAngle = 90f;
    public float maxLookDownAngle = -90f;

    private float rotationX = 0f;

    void Update()
    {
        // Camera rotation with mouse
        RotateCamera();
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate the player horizontally
        transform.parent.Rotate(Vector3.up * mouseX * rotationSpeed);

        // Rotate the camera vertically
        rotationX -= mouseY * rotationSpeed;
        rotationX = Mathf.Clamp(rotationX, maxLookDownAngle, maxLookUpAngle);

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }
}
