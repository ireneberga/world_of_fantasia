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
                    word1 = "resilience";
                    break;
                }
            case 1:
                {
                    word1 = "positivity";
                    break;
                }
            case 2:
                {
                    word1 = "resilience";
                    break;
                }
        }
    }
    private void InitializeSpeechLines()
    {
        // Initialize the list and add your speech lines
        speechLines = new List<string>
        {
            "Hi brave wanderer, I am the turtle of the swamp, one of the spirits that governs this wasteland!",
            "How challenging it is to be a turtle in the fast-paced and frenetic society we live in today, my dear traveller?",
            "In a world that seems to only reward speed, my slowness has always made me the subject of derision. ",
            "I've always been left behind by others; I’ve always watching them achieve their goals before me. ",
            "However, my dear traveler, over time, I've come to understand that my slowness is not a flaw:",
            "It doesn't matter how long it takes me to cover a distance, what really matters is the journey itself. ",
            "Every obstacle I overcome makes me stronger, and every single step, even if slow, brings me closer to my goal. ",
            "I've learned that success does not depend on speed but on the perseverance and determination I have in pursuing what I love.",
            "Remember, my dear traveler, each of us has our own pace, and that life is not a race against others but rather a personal marathon:",
            "only with willpower you will be able to cross the finish line!",
            "Don't rush, but instead PERSEVERE!",
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