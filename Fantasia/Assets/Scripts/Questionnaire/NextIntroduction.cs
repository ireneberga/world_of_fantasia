using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextIntroduction : MonoBehaviour
{
    int anxiety;
    int depression;
    int age;

    int clusterSum;
    int clusterValue;

    private void Awake()
    {
        anxiety = PlayerPrefs.GetInt("AnxietyMultiplier1");
        depression = PlayerPrefs.GetInt("DepreMultiplier1");
        age = PlayerPrefs.GetInt("Age");
    }

    private void Start()
    {
        // Add button click listener
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonPressed);
        }
    }

    public void OnButtonPressed()
    {
        // Calculate clusterSum
        clusterSum = anxiety + depression;

        // Calculate clusterValue based on clusterSum
        if (clusterSum <= 1)
        {
            clusterValue = 0;
        }
        else if (clusterSum > 1 && clusterSum <= 2)
        {
            clusterValue = 1;
        }
        else
        {
            clusterValue = 2;
        }

        // Debug: Print values to the console
        Debug.Log("Cluster Sum: " + clusterSum);
        Debug.Log("Cluster Value: " + clusterValue);
        // Set ClusterValue in PlayerPrefs
        PlayerPrefs.SetInt("ClusterValue", clusterValue);
        
        //riga aggiunta da Elia, provo a salvare una variabile che serve in palude
        PlayerPrefs.SetInt("WordsFound", 0);
        PlayerPrefs.SetInt("word1", 0);
        PlayerPrefs.SetInt("word2", 0);
        PlayerPrefs.SetInt("word3", 0);
        // Change to the next scene (replace "YourNextSceneName" with the actual scene name you want to load)
        PlayerPrefs.Save();
        SceneManager.LoadScene("PALUDE");
    }
}

