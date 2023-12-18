using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class dialogue2: MonoBehaviour
{
    public TextMeshProUGUI textField;
    private List<string> speechLines;
    private int currentLineIndex = 0;
    private int clust;
    private string word2;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        clust = PlayerPrefs.GetInt("ClusterValue");
        switch (clust)
        {
            case 0:
                {
                    word2 = "determination";
                    break;
                }
            case 1:
                {
                    word2 = "habits";
                    break;
                }
            case 2:
                {
                    word2 = "healing";
                    break;
                }
        }       
    }
    private void InitializeSpeechLines()
    {
        // Initialize the list and add your speech lines
        speechLines = new List<string>
        {
            "Hi brave wanderer, I am the frog of the well, one of the spirits that governs this wasteland!",
            "I want to share my story with you, hoping that it can illuminate your path.",
            "For a long time I lived at the bottom of this well.",
            "I didn't need anything else, I was happy confined within the walls of my little refuge, ",
            "protected from the dangers of the outside world and from people's gazes.",
            "However, one day a violent storm flooded my refuge, and I was pushed out into that vast world ",
            "beyond the narrow walls of my well that I feared so much.",
            "It was then that I realized what I had been missing until that moment: I heard colors, sounds and smells that I never imagined could exist.",
            "I met extraordinary creatures, each bringing a unique set of experiences!",
            "I understood the importance of exploring and connecting with the world around me and the desire to know and understand became the driving force of my existence.",
            "My dear traveller, don't make the same mistake as me:",
            "don't stay confined within your inner walls, open up to the outside world, meet new people, new places, new points of view, LIVE!",
            "Remember: How can a frog in a well understand how vast the ocean is?",
            "This is my message: " + word2 + ". Good luck friend!"
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
            PlayerPrefs.SetInt("Word2", 1);

            PlayerPrefs.Save();
            Debug.Log("Updated WordsFound by dialogueWord2: " + currentValue);
            SceneManager.LoadScene("PALUDE");
        }
    }
}