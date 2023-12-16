using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class beforeAnsiaSpeech : MonoBehaviour
{
    public TextMeshProUGUI textField; // Use TextMeshProUGUI instead of Text
    private List<string> speechLines;
    private int currentLineIndex = 0;
    private float age = 35;
    
    //age = PlayerPrefs.GetFloat("Age");
    private void InitializeSpeechLinesold()
    {
        // Initialize the list and add your speech lines
        speechLines = new List<string>
        {
            "You have been great! you should be proud of you!",
            "Now you have improved on managing sadness",
            "you shouldn't regret not having learnt it before, but you should think about how your lifestyle can improve from now on!",
            "take a little time to rest rest because in the following game you will fight the interior monster of anxiety and you will learn how to manage it",
            "you will enjoy a relaxing flight with me while having a five minutes meditation",
            "Click next to start the tutorial",
            
            
        };
    }
    
    private void InitializeSpeechLinesyoung()
    {
        // Initialize the list and add your speech lines
        speechLines = new List<string>
        {
            "Before ansia",
            "Now you have improved on managing sadness",
            "you should think about how your lifestyle can improve from now on!",
            "take a little time to rest rest because in the following game you will fight the interior monster of anxiety and you will learn how to manage it",
            "you will enjoy a relaxing flight with me while having a five minutes meditation",
            "Click next to start the tutorial",
            
        };
    }

    public void ShowTextOnClick()
    {
        // Check if there are still lines in the speech
        if (currentLineIndex == 0)
        {
            if (age > 45)
            {
                InitializeSpeechLinesold();
                textField.text = speechLines[currentLineIndex];
                currentLineIndex++;
            }
            else
            {
                InitializeSpeechLinesyoung();
                textField.text = speechLines[currentLineIndex];
                currentLineIndex++;
            }
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
            SceneManager.LoadScene("TutorialAnsia"); // Make sure the scene name is correct
        }
    }
}