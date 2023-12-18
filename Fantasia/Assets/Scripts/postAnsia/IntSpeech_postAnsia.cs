using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class IntSpeech_postAnsia : MonoBehaviour
{
    public TextMeshProUGUI textField; // Use TextMeshProUGUI instead of Text
    private List<string> speechLines;
    private int currentLineIndex = 0;
    
    private int clustervalue;

    void Awake()
    {
        clustervalue = PlayerPrefs.GetInt("ClusterValue", 2);
    }

    private void InitializeSpeechLines()
    {
        if (clustervalue == 0)
        {
            speechLines = new List<string>
            {
                "Hello there! It's great to have you here for a moment of relaxation.",
                "Life can be busy, especially with family and personal responsibilities.",
                "Today, in the game we explored a simple yet effective technique called Deep Breathing.",
                "It's a helpful tool for those times when you need a moment of calmness.",
                "Find a quiet and comfortable spot to sit or stand.",
                "Inhale slowly through your nose for a count of four.",
                "Hold that breath for another count of four.",
                "Now, exhale gently through your mouth for a count of four.",
                "Repeat this process a few times, allowing stress to melt away.",
                "Give it a try, and let me know how it feels!"
            };
        }
        else if (clustervalue == 1)
        {
            speechLines = new List<string>
            {
                "Welcome back! Our fantastical journey continues.",
                "Today, we practiced Deep Breathing during our trip.",
                "It's a common maneuver used to reduce stress and anxiety levels.",
                "Feeling stressed or anxious in certain moments can happen to everyone.",
                "In those moments that you feel nervous and anxious, I suggest you use this technique.",
                "First, find a quiet and comfortable place to sit or stand.",
                "Now, take a deep breath in through your nose for a count of four.",
                "Hold that breath for a count of four.",
                "Now, exhale slowly through your mouth for a count of four.",
                "Repeat this process a few times until you feel more relaxed.",
                "Give it a try and let me know how it goes!"
            };
        }
        else
        {
            speechLines = new List<string>
            {
                "Hey there! Welcome to our mindfulness moment.",
                "Life can get pretty hectic, especially when you're managing work and personal life.",
                "Today, we used a technique called Deep Breathing, used to tackle stress and anxiety.",
                "It's a valuable skill for those moments when life throws you a curveball.",
                "Find a quiet spot where you can take a breather, literally.",
                "Inhale deeply through your nose, counting to four.",
                "Hold that breath for another count of four.",
                "Now, exhale slowly through your mouth for a count of four.",
                "Repeat this process a few times, allowing yourself to unwind.",
                "Give it a shot, and let me know how it works for you!"
            };
        }
        
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
            SceneManager.LoadScene("Credits");
        }
    }
}



