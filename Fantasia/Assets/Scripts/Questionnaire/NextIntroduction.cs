using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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
        if (anxietyMultiplier < 1 && depreMultiplier < 1 && age > 35)
        {
            clusterValue = 0;
        }
        else if (anxietyMultiplier >= 1 && anxietyMultiplier <= 2 && depreMultiplier <= 1 && age > 35)
        {
            clusterValue = 1;
        }
        else // all the other cases get comprehended in the most delicate cluster
        {
            clusterValue = 2;
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

        PlayerPrefs.SetFloat("lastLocationX", 508);
        PlayerPrefs.SetFloat("lastLocationY", 102);
        PlayerPrefs.SetFloat("lastLocationZ", 1965);
        PlayerPrefs.Save();
        SceneManager.LoadScene("PALUDE");
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

