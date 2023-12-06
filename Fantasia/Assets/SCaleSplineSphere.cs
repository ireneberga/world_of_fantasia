using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleSplineSphere : MonoBehaviour
{
    public float durationEnlarge = 4f;
    public float durationShrink = 4f;
    public float delayBetweenAnimations = 2f;
    public float finalDelay = 2f;

    private float elapsedTime = 0f;
    private bool enlarging = true;

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (enlarging)
        {
            // Allargamento della sfera
            float scale = Mathf.Lerp(1f, 2f, elapsedTime / durationEnlarge);
            transform.localScale = new Vector3(scale, scale, scale);

            if (elapsedTime >= durationEnlarge)
            {
                enlarging = false;
                elapsedTime = 0f;
            }
        }
        else
        {
            // Ritardo tra le animazioni
            if (elapsedTime >= delayBetweenAnimations)
            {
                // Riduzione della sfera
                float scale = Mathf.Lerp(2f, 1f, (elapsedTime - delayBetweenAnimations) / durationShrink);
                transform.localScale = new Vector3(scale, scale, scale);

                if (elapsedTime >= durationShrink + delayBetweenAnimations + finalDelay)
                {
                    enlarging = true;
                    elapsedTime = 0f;
                }
            }
        }
    }
}

