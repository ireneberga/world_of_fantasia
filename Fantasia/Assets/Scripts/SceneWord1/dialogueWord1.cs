using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class dialogue1 : MonoBehaviour
{
    public TextMeshProUGUI textField;
    private List<string> speechLines;
    private int currentLineIndex = 0;
    private int clust;
    private string word1;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        clust = PlayerPrefs.GetInt("ClusterValue");
        switch (clust)
        {
            case 0:
                {
                    word1 = "word1 clust 0";
                    break;
                }
            case 1:
                {
                    word1 = "word1 clust 1";
                    break;
                }
            case 2:
                {
                    word1 = "word1 clust 2";
                    break;
                }
        }
    }
    private void InitializeSpeechLines()
    {
        // Initialize the list and add your speech lines
        speechLines = new List<string>
        {
            "Hi I'm the FIRST CHARACTER!",
            "Welcome to Fantasia, or better to say, what is left...",
            "The Nothing is destroying this wonderful world",
            "The Nothing is the emptiness that surrounds us. It's spreading because people have given up on hoping and forget their own dreams",
            "In order to save Fantasia from the Nothing you have to fight your interiors monsters",
            "In the next page you have to choose the size of the interiors monsters according to the amount of negative influence that have on you",
            "This is for you: " + word1 + ". You can do this!"
            // Add additional speech lines here...
        };
    }

    public void ShowTextOnClick()
    {
        // Check if there are still lines in the speech
        if (currentLineIndex == 0)
        {
            InitializeSpeechLines();
            textField.text = speechLines[currentLineIndex];
            currentLineIndex++;
        }
        else if (currentLineIndex < speechLines.Count)
        {
            // Show the next line of speech
            textField.text = speechLines[currentLineIndex];
            currentLineIndex++;
        }
        else
        {
            int currentValue = PlayerPrefs.GetInt("WordsFound", 0);
            currentValue++;
            PlayerPrefs.SetInt("WordsFound", currentValue);
            PlayerPrefs.SetInt("Word1", 1);

            PlayerPrefs.Save();
            Debug.Log("Updated WordsFound by dialogueWord1: " + currentValue);
            SceneManager.LoadScene("PALUDE"); // Make sure the scene name is correct
        }
    }
}