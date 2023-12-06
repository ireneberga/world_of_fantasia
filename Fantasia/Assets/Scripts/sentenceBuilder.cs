using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sentenceBuilder : MonoBehaviour
{
    public string[] wordsToFind;
    private string[] options;
    private string[] sentencePieces;
    public TMP_Dropdown drop1;
    public TMP_Dropdown drop2;
    public TMP_Dropdown drop3;
    public TMP_Text outputSentenceText;
    private string[] rightWords;
    public Button Button;
    private int cluster = 1;
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Button.enabled = false;
        PopulateDropdown();
        drop1.ClearOptions();
        drop1.AddOptions(new List<string>(options));
        drop2.ClearOptions();
        drop2.AddOptions(new List<string>(options));
        drop3.ClearOptions();
        drop3.AddOptions(new List<string>(options));
        drop1.onValueChanged.AddListener(delegate { UpdateSentence(); });
        drop2.onValueChanged.AddListener(delegate { UpdateSentence(); });
        drop3.onValueChanged.AddListener(delegate { UpdateSentence(); });
        Button.onClick.AddListener(delegate { ChangeScene(); });
        //rightWords = new string[] { "resilience", "determination", "habits" };
        UpdateSentence();
    }
    void UpdateSentence()
    {
        string firstWord = drop1.options[drop1.value].text;
        string secondWord = drop2.options[drop2.value].text;
        string thirdWord = drop3.options[drop3.value].text;
        //string sentence = $"Despite facing challenges, you have shown incredible {firstWord}  in your journey. Your commitment to seeking support is a powerful demonstration of your {secondWord} for a brighter future. Embracing positive {thirdWord} , such as gratitude and self-compassion, can significantly contribute to your overall well-being.";
        string sentence = $"{sentencePieces[0]} <b>{firstWord}</b> {sentencePieces[1]} <b>{secondWord}</b> {sentencePieces[2]} <b>{thirdWord}</b> {sentencePieces[3]}";
        outputSentenceText.text = sentence;
        if (firstWord == rightWords[0] && secondWord == rightWords[1] && thirdWord == rightWords[2])
        {
            Button.enabled = true;
            GameObject.Find("Button").GetComponentInChildren<Text>().text = "Continue";
            //drop1.gameObject.SetActive(false);
            //drop2.gameObject.SetActive(false);
            //drop3.gameObject.SetActive(false);
        }
        else
        {
            Button.enabled = false;
            GameObject.Find("Button").GetComponentInChildren<Text>().text = "";
        }
            
    }
    void ChangeScene()
    {
        //SceneManager.LoadScene("PALUDE", LoadSceneMode.Single);
        SceneManager.LoadScene("PALUDE", LoadSceneMode.Single);
    }

    void PopulateDropdown()
    {
        switch (cluster)
        {
            case 0:
                {
                    options = new string[] { "          ", "surrender", "resilience", "reluctance", "determination", "habits", "pessimism", "cinicism" }; 
                    rightWords = new string[] { "resilience", "determination", "habits" };
                    sentencePieces = new string[] { "Despite facing challenges, you have shown incredible", "in your journey. Your commitment to seeking support is a powerful demonstration of your", "for a brighter future. Embracing positive", ", such as gratitude and self-compassion, can significantly contribute to your overall well-being." };
                    break;
                }
            case 1:
                {
                    options = new string[] { "          ", "unresponsive", "nervousness", "social", " indifference", "self-care", "overindulgence", "positivity" };
                    rightWords = new string[] { "positivity", "self-care", "social" };
                    sentencePieces = new string[] { "Embracing a mindset of", "through intentional daily", ", rituals, building a strong and supportive", "network, and prioritizing self-compassion are key strategies for fostering resilience and managing the challenges of anxiety" };
                    break;
                }
        }
    }
}
