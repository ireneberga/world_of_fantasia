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
    private string[] rightWords;
    // Start is called before the first frame update
    private void Start()
    {
        clust = PlayerPrefs.GetInt("ClusterValue",2);
        Debug.Log("Sentence of cluster:" + clust);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Button.enabled = false;
        switch (clust)
        {
            case 0:
                {
                    word1_string = "resilience";
                    word2_string = "determination";
                    word3_string = "mindset";

                    break;
                }
            case 1:
                {
                    word1_string = "positivity";
                    word2_string = "habits";
                    word3_string = "social";
                    break;
                }
            case 2:
                {
                    word1_string = "strength";
                    word2_string = "resilience";
                    word3_string = "healing";
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
                    options = new string[] { "         ", "surrender", word3_string, "reluctance", word2_string, word1_string, "pessimism", "cinicism", "indifference" };
                    sentencePieces = new string[] { "Despite facing challenges, you have shown incredible", "in your journey. Your commitment to seeking support is a powerful demonstration of your", "for a brighter future. Embracing positive", ", such as gratitude and self-compassion, can significantly contribute to your overall well-being." };
                    break;
                }
            case 1:
                {
                    options = new string[] { "         ", "unresponsive", "nervousness", word2_string, "indifference", word1_string, "overindulgence", word3_string };
                    sentencePieces = new string[] { "Embracing a mindset of", "through intentional daily", ", rituals, building a strong and supportive", "network, and prioritizing self-compassion are key strategies for fostering resilience and managing the challenges of anxiety" };
                    break;
                }
            case 2:
                {
                    options = new string[] { "         ", "unresponsive", "nervousness", word1_string, "indifference", word3_string, "overindulgence", word2_string };
                    sentencePieces = new string[] { "Your journey may be tough, but your "," is undeniable. Remember, your journey is uniquely yours, and every step you take is a testament to your ",". Embrace the light within, and know that, with time, "," unfolds." };
                    break;
                }
        }
    }
}
