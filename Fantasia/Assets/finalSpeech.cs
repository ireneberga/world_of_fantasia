using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class finalSpeech : MonoBehaviour
{
    public TextMeshProUGUI textField; // Use TextMeshProUGUI instead of Text
    private List<string> speechLines;
    private int currentLineIndex = 0;
    
    private int clust; 
    
    private void Awake()
    {
        clust = 0;
        //clust = PlayerPrefs.GetInt("ClusterValue");

        
    }
    
    //age = PlayerPrefs.GetFloat("Age");
    private void InitializeSpeechLineszero()
    {
        // Initialize the list and add your speech lines
        speechLines = new List<string>
        {
            "I hope you feel better now! You have defeated your interior monsters!",
            "Your journey has come to an end and you have saved Fantasia!",
            "Think about the experience that you have done, appreciate what you have learnt and put it in practice in your daily life",
            "May look like little changes but will improve your life and the one of people that are around you",
            "Remember, whenever you need me I'll be here",
            "Good luck my friend!",


        };
    }

    private void InitializeSpeechLinesuno()
        {
                // Initialize the list and add your speech lines
                speechLines = new List<string>
            {
              "I hope you feel better now! You have defeated your interior monsters!",
              "Your journey has come to an end and you have saved Fantasia!", 
              "Remember the person that you were before, appreciate what you have learnt and give you the possibility of a new start",
              "Put in practice what you have learnt and your life and the one of people that are around you will improve",
              "Remember, whenever you need me I'll be here", 
              "Good luck my friend!",
                
                
            };
        }
    
    private void InitializeSpeechLinesdue()
    {
        // Initialize the list and add your speech lines
        speechLines = new List<string>
        {
            "I hope you feel better now! You have defeated your interior monsters!",
            "Your journey has come to an end and you have saved Fantasia!",
            "Remember the person that you were before and appreciate what you have learnt",
            "you have all life ahead to put it in practice and to succeed in the challenges that will present",
            "Remember, whenever you need me I'll be here",
            "Good luck my friend!",
            
        };
    }

    public void ShowTextOnClick()
    {
        // Check if there are still lines in the speech
        if (currentLineIndex == 0)
        {
            if (clust == 0)
            {
                InitializeSpeechLineszero();
                textField.text = speechLines[currentLineIndex];
                currentLineIndex++;
            
            }
            else if (clust == 1)
            {
                InitializeSpeechLinesuno();
                textField.text = speechLines[currentLineIndex];
                currentLineIndex++;
            }
            else
            {
                InitializeSpeechLinesdue();
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
            SceneManager.LoadScene("Monster"); // Make sure the scene name is correct
        }
    }
}
