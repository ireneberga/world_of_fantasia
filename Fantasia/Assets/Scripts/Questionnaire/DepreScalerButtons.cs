using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepreScalerButtons : MonoBehaviour
{
    public Image targetImage;
    private int depreMultiplier;

    void Start()
    {
        depreMultiplier = PlayerPrefs.GetInt("ScaleMultiplier", 1);
        ApplyScale();
    }

    public void OnButtonPressed (int newScaleMultiplier)
    {
        depreMultiplier = newScaleMultiplier;

        PlayerPrefs.SetInt("DepreMultiplier1", depreMultiplier);
        Debug.Log("DepreMultiplier: " + depreMultiplier);
        PlayerPrefs.Save();

        ApplyScale();
    }

    private void ApplyScale()
    {
        if(targetImage != null)
        {
            Vector3 newScale = new Vector3(depreMultiplier*0.5f + 0.5f, depreMultiplier*0.5f + 0.5f, 1f);
            targetImage.rectTransform.localScale = newScale;
        }
    }
}
