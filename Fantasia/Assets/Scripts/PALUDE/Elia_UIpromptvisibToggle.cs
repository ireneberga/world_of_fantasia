using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionPrompt : MonoBehaviour
{
    public float interactionRange = 5f;
    public KeyCode activateKey = KeyCode.E;
    public string[] wordsToFind;
    public int wordsFound;
    public TextMeshProUGUI cornerText;
    public TextMeshProUGUI middleText;
    //private string current_message = "";
    public GameObject Cube;
    public GameObject flower1;
    public GameObject flower2;
    public GameObject flower3;
    public GameObject WordsNPC;
    public GameObject Player;
    private int clust;
    private int word1_bool;
    private int word2_bool;
    private int word3_bool;
    private string word1_string;
    private string word2_string;
    private string word3_string;
    private string[] words_clust_0;
    private string[] words_clust_1;
    private string[] words_clust_2;
    private int currentWordsFound;
    private void Start()
    {
        if (PlayerPositionManager.GetSavedPlayerPosition() != Vector3.zero)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            transform.position = PlayerPositionManager.GetSavedPlayerPosition();
            player.transform.position = PlayerPositionManager.GetSavedPlayerPosition();
            Debug.Log("Player position set when entering the main scene: " + player.transform.position);
        }
        words_clust_0 = new string[] { "clust_0_word_1", "clust_0_word_2", "clust_0_word_3" };
        words_clust_1 = new string[] { "clust_1_word_1", "clust_1_word_2", "clust_1_word_3" };
        words_clust_2 = new string[] { "clust_2_word_1", "clust_2_word_2", "clust_2_word_3" };
        
        word1_bool = PlayerPrefs.GetInt("Word1",0);
        word2_bool = PlayerPrefs.GetInt("Word2",0);
        word3_bool = PlayerPrefs.GetInt("Word3",0);
        
        clust = PlayerPrefs.GetInt("ClusterValue");
        Debug.Log("parole trovate: " + word1_bool + " " + word2_bool + " " + word3_bool);
        PlayerPrefs.Save();
        ShowPrompt("");
        switch (clust)
        {
            case 0:
                {
                    word1_string = words_clust_0[0];
                    word2_string = words_clust_0[1];
                    word3_string = words_clust_0[2];
                    break;
                }
            case 1:
                {
                    word1_string = words_clust_1[0];
                    word2_string = words_clust_1[1];
                    word3_string = words_clust_1[2];
                    break;
                }
            case 2:
                {
                    word1_string = words_clust_2[0];
                    word2_string = words_clust_2[1];
                    word3_string = words_clust_2[2];
                    break;
                }
        }
        //wordsToFind = new string[] { "Resilience", "Determination", "Habits" };
        //string sentence = $"{word1_string} {word2_string} {word3_string}";
        //Debug.Log("Parole da trovare:" + sentence);
        currentWordsFound = PlayerPrefs.GetInt("WordsFound", 0);
        if (currentWordsFound > 3)
        {
            Cube.SetActive(false);
            //Player.transform.position = new Vector3(602, 105, 1082);
            //flower1.tag = "retrieved";
            //flower2.tag = "retrieved";
            //flower3.tag = "retrieved";
            //WordsNPC.tag = "Untagged";
        }
        UpdateWordsFound();

    }
    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit, interactionRange))
        {
            if (hit.collider.CompareTag("obstacle"))
            {
                ShowPrompt("You can't go this way!");
            }
            else if (hit.collider.CompareTag("SceneTransitioner"))
            {
                ShowPrompt("Go forward to meet Falkor");
                if (Input.GetKey(activateKey))
                {
                    SceneManager.LoadScene("beforeAnsia");
                }
            }
            else if (hit.collider.CompareTag("NPC_Word1"))
            {
                if (word1_bool == 1)
                {
                    ShowPrompt("You already spoke with me!");
                }
                else
                {
                    ShowPrompt("Press E to speak");
                    if (Input.GetKey(activateKey))
                    {
                        SceneManager.LoadScene("scene_word_1");
                    }
                }
                
            }
            else if (hit.collider.CompareTag("NPC_Word2"))
            {
                if (word2_bool == 1)
                {
                    ShowPrompt("You already spoke with me!");
                }
                else
                {
                    ShowPrompt("Press E to speak");
                    if (Input.GetKey(activateKey))
                    {
                        SceneManager.LoadScene("scene_word_2");
                    }
                }

            }
            else if (hit.collider.CompareTag("NPC_Word3"))
            {
                if (word3_bool == 1)
                {
                    ShowPrompt("You already spoke with me!");
                }
                else
                {
                    ShowPrompt("Press E to speak");
                    if (Input.GetKey(activateKey))
                    {
                        SceneManager.LoadScene("scene_word_3");
                    }
                }

            }
            else if (hit.collider.CompareTag("speakable"))
            {
                ShowPrompt("Press E to speak!");
                if (Input.GetKey(activateKey))
                {
                    if (currentWordsFound == 3)
                    {
                        SceneManager.LoadScene("make_sentence", LoadSceneMode.Single);
                    }
                    else if (currentWordsFound > 3) {
                        ShowPrompt("You are ready to continue in your journey!");
                    }
                    else if (currentWordsFound < 3)
                    {
                        ShowPrompt("You need to find more words!");
                    }


                }
            }
            }
        else
        {
            ShowPrompt("");
        }
    }

        void ShowPrompt(string message)
        {
            if (middleText != null && middleText.gameObject.activeSelf)
            {
                middleText.text = message;
            }
        }
        void UpdateWordsFound()
        {
            cornerText.text = "";
            if (word1_bool == 1)
            {
                cornerText.text += word1_string + "\n";
            }
            if (word2_bool == 1)
            {
                cornerText.text += word2_string + "\n";
            }
            if (word3_bool == 1)
            {
                cornerText.text += word3_string;
            }
        }

}
/*
    void ShowPrompt(string message)
    {
        if (middleText != null && middleText.gameObject.activeSelf)
        {
            middleText.text = message;
        }
    }*/
/* qursto era lo script di scenetransitioner
using UnityEngine;
public class GameData : MonoBehaviour
{
    public static bool wordsCollected = false;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

*/

