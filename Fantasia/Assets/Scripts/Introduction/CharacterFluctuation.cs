using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFluctuation : MonoBehaviour
{
    public float fluctuationAmount = 0.1f;  // Adjust the amount of fluctuation
    public float fluctuationSpeed = 1.5f;   // Adjust the speed of fluctuation
    private Vector3 originalPosition;

    void Start()
    {
        // Save the original position of the character
        originalPosition = transform.position;
    }

    void Update()
    {
        // Simulate fluctuation using a sine wave
        float fluctuation = Mathf.Sin(Time.time * fluctuationSpeed) * fluctuationAmount;

        // Apply fluctuation to the character's Y position
        Vector3 newPosition = originalPosition + new Vector3(0f, fluctuation, 0f);
        transform.position = newPosition;
    }
}

