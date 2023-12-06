using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject dragon;
    
    private Vector3 offset = new Vector3(0, 3.5f, -1);
    
    // Update is called once per frame
    void Update()
    {
        transform.position = dragon.transform.position + offset;
    }
    
}
