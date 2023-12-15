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
    private float age = 35;
    
    //age = PlayerPrefs.GetFloat("Age");
    private void InitializeSpeechLinesold()
    {
        // Initialize the list and add your speech lines
        speechLines = new List<string>
        {
            "I hope you feel better now! You have defeated your interior monsters!",
            "Your journey has come to an end and you have saved Fantasia!",
            "Remember the person that you were before, appreciate what you have learnt and give you the possibility of a new start",
            "Remember, whenever you need me I'll be here",
            "Good luck my friend!",
            
            
        };
    }
    
    private void InitializeSpeechLinesyoung()
    {
        // Initialize the list and add your speech lines
        speechLines = new List<string>
        {
            "I hope you feel better now! You have defeated your interior monsters!",
            "Your journey has come to an end and you have saved Fantasia!",
            "Think about all the improvements that you have done and what you have learnt",
            "you have all life ahead you to put them in practice",
            "Remember, whenever you need me I'll be here",
            "Good luck my friend!",
            
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
            SceneManager.LoadScene("Monster"); // Make sure the scene name is correct
        }
    }
}
