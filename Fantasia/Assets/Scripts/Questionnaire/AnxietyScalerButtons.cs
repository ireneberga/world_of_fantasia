using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnxietyScalerButtons : MonoBehaviour
{
    public Image targetImage;
    private int anxietyMultiplier;

    void Start()
    {
        anxietyMultiplier = PlayerPrefs.GetInt("ScaleMultiplier", 1);
        ApplyScale();
    }

    public void OnButtonPressed (int newScaleMultiplier)
    {
        anxietyMultiplier = newScaleMultiplier;

        PlayerPrefs.SetInt("AnxietyMultiplier1", anxietyMultiplier);
        Debug.Log("AnxietyMultiplier: " + anxietyMultiplier);
        PlayerPrefs.Save();

        ApplyScale();
    }

    private void ApplyScale()
    {
        if(targetImage != null)
        {
            Vector3 newScale = new Vector3(anxietyMultiplier*0.5f + 0.5f, anxietyMultiplier*0.5f + 0.5f, 1f);
            targetImage.rectTransform.localScale = newScale;
        }
    }
}