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
    public GameObject sfondo;
    private void Awake()
    {
        sfondo.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        clust = PlayerPrefs.GetInt("ClusterValue");
        switch (clust)
        {
            case 0:
                {
                    word3 = "mindset";
                    break;
                }
            case 1:
                {
                    word3 = "socialization";
                    break;
                }
            case 2:
                {
                    word3 = "strength";
                    break;
                }
        }
    }
    private void InitializeSpeechLines()
    {
        // Initialize the list and add your speech lines
        speechLines = new List<string>
        {
            "Who is there? I can’t see you, because, as you can see, I'm blind.",
            "Anyway, whoever you are, let me introduce myself: I am the blind mole, one of the spirits that rules this wasteland.",
            "I live in eternal darkness, without ever having been able to see the light of day.",
            "It is a deep desire, to be able to see the wonders of the world that others describe, which unfortunately life has denied me.",
            "Precisely for this reason I had to learn to discover the world through other senses.",
            "However, my dear traveller, I want to ask you a question: is it enough to have sight to not be blind?",
            "Over time I realized that many people, despite having sight, are actually blinder than me:",
            "although their eyes can capture the beauty, denied to me, they often lack the ability to appreciate what is in front of them.",
            "In fact, many get lost in their daily routine, in the anxieties of the future or in the regrets of the past,",
            "without ever raising their eyes to enjoy the beauties that life offers them in the present.",
            "My dear traveller, don't make the same mistake:",
            "free your gaze from the chains of indifference and habit and learn to find joy in details, to be amazed",
            "by the small daily miracles and to immerse yourself in the emotions that the world has to offer.",
            "Look beyond the surface, and you will discover that even the most common things hide a treasure of beauty!",
            "The word I give you is " + word3 + ", good luck in your journey!"
            // Add additional speech lines here...
        };
    }

    public void ShowTextOnClick()
    {
        // Check if there are still lines in the speech
        if (currentLineIndex == 0)
        {
            sfondo.gameObject.SetActive(true);
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
            PlayerPrefs.SetInt("Word3", 1);

            PlayerPrefs.Save();
            Debug.Log("Updated WordsFound by dialogueWord3: " + currentValue);
            sfondo.gameObject.SetActive(false);
            SceneManager.LoadScene("PALUDE"); // Make sure the scene name is correct
        }
    }
}