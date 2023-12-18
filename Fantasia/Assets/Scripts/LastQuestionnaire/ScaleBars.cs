using UnityEngine;
using UnityEngine.UI;

public class ScaleBars : MonoBehaviour
{
    public RawImage rawImage1; // Reference to the RectTransform of the first bar
    public RawImage rawImage2; // Reference to the RectTransform of the second bar

    // Set the maximum scale factor for both bars
    public float maxScale = 24.0f;

    // Reference to the script that calculates sum values
    public AssignValuesAndSum assignValuesAndSumScript;

    void Start()
    {
        // Make sure the bar references are set
        if (rawImage1 == null)
        {
            Debug.LogError("Bar1 reference is not set. Please assign it in the inspector.");
            return;
        }

        if (rawImage2 == null)
        {
            Debug.LogError("Bar2 reference is not set. Please assign it in the inspector.");
            return;
        }

        // Make sure the AssignValuesAndSum script reference is set
        if (assignValuesAndSumScript == null)
        {
            Debug.LogError("AssignValuesAndSum script reference is not set. Please assign it in the inspector.");
            return;
        }

        // Call a method to scale the bars based on calculated sums
        ScaleBarsBasedOnSums();
    }

    void ScaleBarsBasedOnSums()
    {
        // Get the sum values from the AssignValuesAndSum script
        int sum1 = assignValuesAndSumScript.sum1;
        int sum2 = assignValuesAndSumScript.sum2;

        // Calculate the scale factors based on the sums
        float scaleFactor1 = Mathf.Clamp01((float)sum1);
        float scaleFactor2 = Mathf.Clamp01((float)sum2);

        // Set the scales of the bars
        SetRawImageScale(rawImage1, scaleFactor1);
        SetRawImageScale(rawImage2, scaleFactor2);
    }

    void SetRawImageScale(RawImage image, float scaleFactor)
    {
        // Get the RectTransform component of the RawImage
        RectTransform rectTransform = image.GetComponent<RectTransform>();

        // Set the scale only on the Y-axis to make it grow upwards
        rectTransform.localScale = new Vector3(1.0f, scaleFactor, 1.0f);
    }
}
