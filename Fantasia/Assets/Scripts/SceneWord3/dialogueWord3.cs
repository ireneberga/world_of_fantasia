using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class dialogue3 : MonoBehaviour
{
    public TextMeshProUGUI textField; // Use TextMeshProUGUI instead of Text
    private List<string> speechLines;
    private int currentLineIndex = 0;
    private int clust;
    private string word3;
    private void Awake()
    {
        clust = PlayerPrefs.GetInt("ClusterValue");
        switch (clust)
        {
            case 0:
                {
                    word3 = "word3 clust 0";
                    break;
                }
            case 1:
                {
                    word3 = "word3 clust 1";
                    break;
                }
            case 2:
                {
                    word3 = "word3 clust 2";
                    break;
                }
        }
    }
    private void InitializeSpeechLines()
    {
        // Initialize the list and add your speech lines
        speechLines = new List<string>
        {
            "Hi I'm the THIRD CHARACTER!",
            "Welcome to Fantasia, or better to say, what is left...",
            "The Nothing is destroying this wonderful world",
            "The Nothing is the emptiness that surrounds us. It's spreading because people have given up on hoping and forget their own dreams",
            "In order to save Fantasia from the Nothing you have to fight your interiors monsters",
            "In the next page you have to choose the size of the interiors monsters according to the amount of negative influence that have on you",
            "The word I give you is" + word3 + ", good luck in your journey!"
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
            // If the speech is complete, move to scene 2
            SceneManager.LoadScene("MonsterChoicePie"); // Make sure the scene name is correct
        }
    }
}