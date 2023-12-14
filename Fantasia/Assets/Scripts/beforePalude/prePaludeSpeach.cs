using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class prePaludeSpeach : MonoBehaviour
{
    public TextMeshProUGUI textField; // Use TextMeshProUGUI instead of Text
    private List<string> speechLines;
    private int currentLineIndex = 0;

    private void InitializeSpeechLines()
    {
        // Initialize the list and add your speech lines
        speechLines = new List<string>
        {
            "Look, you identified your interiors monsters and Fantasia is already getting better!",
            "The trees are growing again! Who knows the improvements that you can get going on in your journey...",
            "Now you will enter in the swamp of sadness and you will learn how not to be overwhelmed by bad thoughts,",
            "but always looking for something positive!",
            "Don't give up if you feel disoriented",
            "I'm your friend, I believe in you and I will be waiting for you at the end. Good luck!"
            
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
            SceneManager.LoadScene("Monster"); // Make sure the scene name is correct
        }
    }
}
