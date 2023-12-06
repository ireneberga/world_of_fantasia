using System;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    public Rigidbody dragon;

   
    private void Update()
    {
        dragon.AddForce(0, 0, 10 * Time.deltaTime);
        
        float moveForce = 800f * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dragon.velocity = new Vector3(-moveForce, dragon.velocity.y, dragon.velocity.z);
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dragon.velocity = new Vector3(moveForce, dragon.velocity.y, dragon.velocity.z);
        }
         
    }
}
    


   

