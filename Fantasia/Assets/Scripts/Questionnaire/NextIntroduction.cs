using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.Presets;

public class NextIntroduction : MonoBehaviour
{
    public Slider mySlider;
    public TextMeshProUGUI myText;

    int clusterSum;
    int clusterValue;

    public Image targetImage_d;
    private int depreMultiplier;

    public Image targetImage1;
    private int anxietyMultiplier;

    private float age;

    private void Start()
    {  
        depreMultiplier = PlayerPrefs.GetInt("ScaleMultiplier", 1);
        ApplyScaleDepre();
        anxietyMultiplier = PlayerPrefs.GetInt("ScaleMultiplier", 1);
        ApplyScaleAnxiety();
        // Add button click listener
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonPressed);
        }

        mySlider.onValueChanged.AddListener(UpdateTextValue);
        age = mySlider.value;
    }

    public void OnButtonAnx (int newScaleMultiplier_a)
    {
        anxietyMultiplier = newScaleMultiplier_a;
        Debug.Log("AnxietyMultiplier: " + anxietyMultiplier);

        ApplyScaleAnxiety();
    }

    public void OnButtonDep (int newScaleMultiplier_d)
    {
        depreMultiplier = newScaleMultiplier_d;
        Debug.Log("DepreMultiplier1: " + depreMultiplier);

        ApplyScaleDepre();
    }

    public void OnButtonPressed()
    {
        // Calculate clusterSum
        clusterSum = anxietyMultiplier + depreMultiplier;

        // Calculate clusterValue based on clusterSum
        if (age < 35  && anxietyMultiplier > 1 && depreMultiplier > 0)
        {
            clusterValue = 2;
        }
        else if (age > 35 && anxietyMultiplier > 0 && depreMultiplier > 0)
        {
            clusterValue = 1;
        }
        else
        {
            clusterValue = 0;
        }

        // Debug: Print values to the console
        Debug.Log("Cluster Sum: " + clusterSum);
        Debug.Log("Cluster Value: " + clusterValue);
        // Set ClusterValue in PlayerPrefs
        PlayerPrefs.SetInt("ClusterValue", clusterValue);
        PlayerPrefs.SetInt("DepreMultiplier1", depreMultiplier);
        PlayerPrefs.SetInt("AnxietyMultiplier1", anxietyMultiplier);
        PlayerPrefs.SetFloat("Age", age);
        
        //riga aggiunta da Elia, provo a salvare una variabile che serve in palude
        PlayerPrefs.SetInt("WordsFound", 0);
        PlayerPrefs.SetInt("Word1", 0);
        PlayerPrefs.SetInt("Word2", 0);
        PlayerPrefs.SetInt("Word3", 0);

        PlayerPrefs.SetFloat("lastLocationX", 620);
        PlayerPrefs.SetFloat("lastLocationY", 102);
        PlayerPrefs.SetFloat("lastLocationZ", 1907);
        PlayerPrefs.SetInt("tutorialDone",0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("beforePalude");
    }

    private void ApplyScaleAnxiety()
    {
        if(targetImage1 != null)
        {
            Vector3 newScale = new Vector3(anxietyMultiplier*0.5f + 0.5f, anxietyMultiplier*0.5f + 0.5f, 1f);
            targetImage1.rectTransform.localScale = newScale;
        }
    }

    private void ApplyScaleDepre()
    {
        if(targetImage_d != null)
        {
            Vector3 newScale = new Vector3(depreMultiplier*0.5f + 0.5f, depreMultiplier*0.5f + 0.5f, 1f);
            targetImage_d.rectTransform.localScale = newScale;
        }
    }

    private void UpdateTextValue(float value)
    {
        // Update the text with the current slider value
        myText.text = "" + value.ToString(); // Displaying the value with two decimal places

        // Update the age variable in real-time
        age = value;
    }
}

