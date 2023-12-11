using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;
    public Transform orientation;
    //public Canvas sentenceCanvas
    float xRotation;
    float YRotation;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        YRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, YRotation, 0);
        orientation.rotation = Quaternion.Euler(0, YRotation, 0);
        float yRotation = transform.rotation.eulerAngles.y;
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}