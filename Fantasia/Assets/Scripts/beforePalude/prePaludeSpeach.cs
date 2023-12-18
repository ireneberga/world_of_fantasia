using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class prePaludeSpeach : MonoBehaviour
{
    public TextMeshProUGUI textField;
    private List<string> speechLines;
    private int currentLineIndex = 0;
    private int clust;
    public GameObject sfondo;
    
    private void Awake()
    {
        //clust = 1;
        clust = PlayerPrefs.GetInt("ClusterValue");
        sfondo.gameObject.SetActive(false);

        
    }

    private void InitializeSpeechLineszero()
    {
        speechLines = new List<string>
        {
            "Look, you identified your interiors monsters and Fantasia is already getting better!",
            "Who knows the improvements that you can get going on in your journey...",
            "In your life it may be happened several times to be sad",
            "In the next level you will learn how to better manage these situations for you, for your family and for the people that you love",
            "You will enter in the swamp of sadness, you may drown if you don't let someone help you",
            "In the game you have to look for the spirits, they will guide you through the end of the swamp",
            "In the real life you may rely on your family and on your friends to get through the hard moments", 
            "Here you will learn how not to be overwhelmed by bad thoughts, but to always look for something positive!",
            "Have fun exploring and and try to get the best that you can from this experience",
            "I will be waiting for you at the end. Good luck!"
            
        };
    }
    
    private void InitializeSpeechLinesuno()
    {
        speechLines = new List<string>
        {
            "Look, you identified your interiors monsters and Fantasia is already getting better!",
            "Who knows the improvements that you can get going on in your journey...",
            "Now you will enter in the swamp of sadness, you may drown if you don't let someone help you",
            "In the game you have to look for the spirits, they will guide you through the end of the swamp",
            "In the real life you may rely on your family and on your friends to get through the hard moments", 
            "you will learn managing some situations and always looking for something positive!",
            "You, your family and the people that you love will take advantage from this",
            "Don't give up if you feel disoriented",
            "I'm your friend, I believe in you and I will be waiting for you at the end. Good luck!"
            
        };
    }
    
    private void InitializeSpeechLinesdue()
    {
        speechLines = new List<string>
        {
            "Look, you identified your interiors monsters and Fantasia is already getting better!",
            "Who knows the improvements that you can get going on in your journey...",
            "Now you will enter in the swamp of sadness, you may drown if you don't let someone help you",
            "In the game you have to look for the spirits, they will guide you through the end of the swamp",
            "In the real life you may rely on your friends and on people that love you to get through the hard moments.",
            "Here you will learn managing some situations and always looking for something positive!",
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
            sfondo.gameObject.SetActive(true);
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
            SceneManager.LoadScene("PALUDE"); 
        }
    }
}
