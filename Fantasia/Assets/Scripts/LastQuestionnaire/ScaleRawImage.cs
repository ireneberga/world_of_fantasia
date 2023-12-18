using UnityEngine;
using UnityEngine.UI;

public class ScaleRawImages : MonoBehaviour
{
    public RawImage rawImage1; // Reference to the first RawImage component
    public RawImage rawImage2; // Reference to the second RawImage component

    // Set the maximum scale factor for both RawImages
    public float maxScale = 3.0f;

    private int anxiety;
    private int depression; 

    void Awake()
    {
        anxiety = PlayerPrefs.GetInt("AnxietyMultiplier1", 1);
        depression = PlayerPrefs.GetInt("DepreMultiplier1", 1);
    }

    void Start()
    {
        // Make sure the rawImage1 and rawImage2 references are set
        if (rawImage1 == null)
        {
            Debug.LogError("RawImage1 reference is not set. Please assign it in the inspector.");
            return;
        }

        if (rawImage2 == null)
        {
            Debug.LogError("RawImage2 reference is not set. Please assign it in the inspector.");
            return;
        }

        // Call a method to scale the RawImages based on stored values
        ScaleRawImagesBasedOnStoredValues();
    }

    void ScaleRawImagesBasedOnStoredValues()
    {
        // Retrieve the stored values from PlayerPrefs
        float floatanxiety = (float)anxiety;
        float floatdepression = (float)depression;

        // Calculate the scale factors based on the stored values
        float scaleFactor1 = Mathf.Clamp01(floatanxiety / maxScale);
        float scaleFactor2 = Mathf.Clamp01(floatdepression / maxScale);

        // Set the scales of the RawImages
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


