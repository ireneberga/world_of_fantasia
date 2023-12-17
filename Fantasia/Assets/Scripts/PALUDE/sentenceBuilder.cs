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
    public Button Button;
    private int clust;
    private string word1_string;
    private string word2_string;
    private string word3_string;
    // Start is called before the first frame update
    private void Start()
    {
        clust = PlayerPrefs.GetInt("ClusterValue");
        Debug.Log("Sentence of cluster:" + clust);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Button.enabled = false;
        switch (clust)
        {
            case 0:
                {
                    word1_string = "word_1_clust_0";
                    word2_string = "word_2_clust_0";
                    word3_string = "word_3_clust_0";
                    break;
                }
            case 1:
                {
                    word1_string = "word_1_clust_1";
                    word2_string = "word_2_clust_1";
                    word3_string = "word_3_clust_1";
                    break;
                }
            case 2:
                {
                    word1_string = "word_1_clust_2";
                    word2_string = "word_2_clust_2";
                    word3_string = "word_3_clust_2";
                    break;
                }
        }
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
        if (firstWord == word1_string && secondWord == word2_string && thirdWord == word3_string)
        {
            Button.enabled = true;
            GameObject.Find("Button").GetComponentInChildren<Text>().text = "Continue";
        }
        else
        {
            Button.enabled = false;
            GameObject.Find("Button").GetComponentInChildren<Text>().text = "";
        }

    }
    void ChangeScene()
    {
        SceneManager.LoadScene("beforeAnsia");
    }

    void PopulateDropdown()
    {
        switch (clust)
        {
            case 0:
                {
                    options = new string[] { "          ", "surrender", word1_string, "reluctance", word2_string, word3_string, "pessimism", "cinicism" };
                    sentencePieces = new string[] { "Cluster 0: Despite facing challenges, you have shown incredible", "in your journey. Your commitment to seeking support is a powerful demonstration of your", "for a brighter future. Embracing positive", ", such as gratitude and self-compassion, can significantly contribute to your overall well-being." };
                    break;
                }
            case 1:
                {
                    options = new string[] { "          ", "unresponsive", "nervousness", word1_string, " indifference", word2_string, "overindulgence", word3_string };
                    sentencePieces = new string[] { "Cluster 1: Embracing a mindset of", "through intentional daily", ", rituals, building a strong and supportive", "network, and prioritizing self-compassion are key strategies for fostering resilience and managing the challenges of anxiety" };
                    break;
                }
            case 2:
                {
                    options = new string[] { "          ", "unresponsive", "nervousness", word1_string, " indifference", word2_string, "overindulgence", word3_string };
                    sentencePieces = new string[] { "Cluster 2: Embracing a mindset of", "through intentional daily", ", rituals, building a strong and supportive", "network, and prioritizing self-compassion are key strategies for fostering resilience and managing the challenges of anxiety" };
                    break;
                }
        }
    }
}
