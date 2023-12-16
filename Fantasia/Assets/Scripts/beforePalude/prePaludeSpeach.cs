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
    private int clust; 
    
    private void Awake()
    {
        //clust = 1;
        clust = PlayerPrefs.GetInt("ClusterValue");

        
    }

    private void InitializeSpeechLineszero()
    {
        // Initialize the list and add your speech lines
        //low levels of anxiaty and depression, age 45
        speechLines = new List<string>
        {
            "Look, you identified your interiors monsters and Fantasia is already getting better!",
            "The trees are growing again! Who knows the improvements that you can get going on in your journey...",
            "In your life it may be happened several times to be stressed or sad",
            "During the journey you will learn how to better manage these situations for you, for your family and for the people that you love",
            "Now you will enter in the swamp of sadness",
            "you will learn how not to be overwhelmed by bad thoughts, but to always look for something positive!",
            "Have fun exploring and and try to get the best that you can from this experience",
            "I will be waiting for you at the end. Good luck!"
            
        };
    }
    
    private void InitializeSpeechLinesuno()
    {
        // Initialize the list and add your speech lines
        // medium levels of anxiety and depression, age 45
        speechLines = new List<string>
        {
            "Look, you identified your interiors monsters and Fantasia is already getting better!",
            "The trees are growing again! Who knows the improvements that you can get going on in your journey...",
            "Now you will enter in the swamp of sadness",
            "you will learn managing some situations and always looking for something positive!",
            "You, your family and the people that you love will take advantage from this",
            "Don't give up if you feel disoriented",
            "I'm your friend, I believe in you and I will be waiting for you at the end. Good luck!"
            
        };
    }
    
    private void InitializeSpeechLinesdue()
    {
        // Initialize the list and add your speech lines
        // medium level of depression, hihgh level of anxiety. Age 25
        speechLines = new List<string>
        {
            "Look, you identified your interiors monsters and Fantasia is already getting better!",
            "The trees are growing again! Who knows the improvements that you can get going on in your journey...",
            "Now you will enter in the swamp of sadness",
            "you will learn managing some situations and always looking for something positive!",
            "In the future you will take advantage from this, it will be easier for you to reach your goals",
            "Don't give up if you feel disoriented",
            "I'm your friend, I believe in you and I will be waiting for you at the end. Good luck!"
            
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