using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCloud : MonoBehaviour
{
    public float initialPauseDuration = 0.25f;
    public float shrinkDuration = 3.8f;
    public float intermediatePauseDuration = 2f;
    public float enlargeDuration = 3.8f;

    private float elapsedTime = 0f;
    private bool shrinking = false;
    private bool ristretto = false;
    private bool allargato = false; 
    private bool enlarging = false;
    private bool isPaused = false;

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (isPaused)
        {
            // Pausa tra le animazioni
            if (elapsedTime >= intermediatePauseDuration)
            {
                if (ristretto == true)
                {
                    isPaused = false;
                    ristretto = false;
                    enlarging = true;
                    elapsedTime = 0f;
                }
                else if (allargato == true)
                {
                    isPaused = false;
                    allargato = false;
                    shrinking = true;
                    elapsedTime = 0f;
                }
                
            }
        }
        else if (shrinking)
        {
            // Riduzione della sfera
            float scale = Mathf.Lerp(0.015f, 0.01f, elapsedTime / shrinkDuration);
            transform.localScale = new Vector3(scale, scale, scale);

            if (elapsedTime >= shrinkDuration)
            {
                shrinking = false;
                isPaused = true;
                ristretto = true; 
                elapsedTime = 0f;
            }
        }
        else if (enlarging)
        {
            // Allargamento della sfera
            float scale = Mathf.Lerp(0.01f, 0.015f, elapsedTime / enlargeDuration);
            transform.localScale = new Vector3(scale, scale, scale);

            if (elapsedTime >= enlargeDuration)
            {
                enlarging = false;
                isPaused = true;
                allargato = true;
                elapsedTime = 0f;
            }
        }
        else
        {
            // Pausa iniziale
            
            // Allargamento della sfera
            float scale = Mathf.Lerp(0.01f, 0.015f, elapsedTime / initialPauseDuration);
            transform.localScale = new Vector3(scale, scale, scale);
            
             if (elapsedTime >= initialPauseDuration)
             {
                 shrinking = true;
                 elapsedTime = 0f;
             }
        }
    }
}


