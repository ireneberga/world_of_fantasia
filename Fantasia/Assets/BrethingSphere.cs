using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrethingSphere : MonoBehaviour
{
    public GameObject dragon;
    
    private Vector3 offset = new Vector3(0, 8, 9);
   
    
    
    // Update is called once per frame
    void Update()
    {
        transform.position = dragon.transform.position + offset;
        
        
    }
}
