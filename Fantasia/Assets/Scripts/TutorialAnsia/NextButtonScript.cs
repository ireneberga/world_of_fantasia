using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextButtonScript : MonoBehaviour
{
    public Text TutorialText;
    public Text warn;

    //public Button showTextButton;
    private List<string> speechLines;
    private int currentLineIndex = 0;
    public GameObject heart1, heart2, heart3, layer1, layer2, layer3, gameover, arrowup, arrowdown;
    public GameObject indcloud, indlives;

    //private string _mostro1 = "small anxia";
    //public static bool flagtut = false;
    //private int contatorePulsanti = 0;
    private string _mostro2 ;

    private int clust;
    private string username;
    private int age;
    
    private void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        clust = 0;
        //clust = PlayerPrefs.GetInt("ClusterValue");
        //age = PlayerPrefs.GetInt("Age");
        age = 50;
        username = PlayerPrefs.GetString("Username");


    }

    void Start()
    {
        if (clust == 0)
        {
            _mostro2 = "small anxia";
            
        }
        else if (clust == 1)
        {
            _mostro2 = "medium anxia";
        }
        else
        {
            _mostro2 = "big anxia";
        }

        heart1.gameObject.SetActive(false);
        heart2.gameObject.SetActive(false);
        heart3.gameObject.SetActive(false);
        layer1.gameObject.SetActive(false);
        layer2.gameObject.SetActive(false);
        layer3.gameObject.SetActive(false);
        gameover.gameObject.SetActive(false);
        arrowup.gameObject.SetActive(false);
        arrowdown.gameObject.SetActive(false);
        indcloud.gameObject.SetActive(false);
        indlives.gameObject.SetActive(false);
        warn.text = "";
        
        Debug.Log(_mostro2 + " start");
        Debug.Log(username + " start");



    }

    private void InitializeSpeechLines()
    {
        // Inizializza la lista e aggiungi le tue linee di discorso
        speechLines = new List<string>();
        speechLines.Add(
            "In the following game the dragon will move up and down according to the rhythm of the breath, try to follow it with the arrows of your board");
        TutorialCharacterMovement.active = true;

        if (age > 45)
        {
            arrowup.gameObject.SetActive(true);
            arrowdown.gameObject.SetActive(true);
            indcloud.gameObject.SetActive(true);
        }

        if (_mostro2 == "big anxia")
        {
            speechLines.Add("Now that you have understood how it works let's have five minutes of relaxation");
        }
        else if (_mostro2 == "medium anxia")
        {
            speechLines.Add(
                "If you press the the wrong arrow or the rhythm with which you press the arrows is wrong for too many times a warning will appear");
            speechLines.Add("Try to correct yourself and enjoy five minutes of relaxation ");
        }
        else if (_mostro2 == "small anxia")
        {
            speechLines.Add("The lives that you have left are shown in the up left corner");
            // TranslateObject(heart1);
            // TranslateObject(heart2);
            // TranslateObject(heart3);
            // TranslateObject(layer1);
            // TranslateObject(layer2);
            // TranslateObject(layer3);
            speechLines.Add(
                "If you press the the wrong arrow or the rhythm with which you press the arrows is wrong for too many times the number of lives that you have left will decrease");
            speechLines.Add("If you loose all your lives you will restart the five minutes of meditation");

        }


        // Aggiungi ulteriori linee di discorso qui...
    }

    public void ShowTextOnClick()
    {
        Debug.Log(currentLineIndex);
        // Controlla se ci sono ancora linee nel discorso
        if (currentLineIndex == 0)
        {
            InitializeSpeechLines();
            TutorialText.text = speechLines[currentLineIndex];
            if (_mostro2 == "small anxia")
            {
                heart1.gameObject.SetActive(true);
                layer1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                layer2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                layer3.gameObject.SetActive(true);
            }

            currentLineIndex++;
        }
        else if (currentLineIndex < speechLines.Count)
        {
           arrowup.gameObject.SetActive(false);
           arrowdown.gameObject.SetActive(false);
           indcloud.gameObject.SetActive(false);
            
            
            // Mostra la prossima linea del discorso
            TutorialText.text = speechLines[currentLineIndex];
            
            if (_mostro2 == "small anxia")
            {
                if(currentLineIndex == 1)
                {
                    if(age>45)
                    {
                        indlives.gameObject.SetActive(true);
                    }
                        
                }
                else if (currentLineIndex == 2)
                {
                    heart3.gameObject.SetActive(false);
                    
                    if(age>45)
                    {
                      indlives.gameObject.SetActive(false);
                     }

                }
                else if (currentLineIndex == 3)
                {
                    gameover.gameObject.SetActive(true);
                }
            }

            if (_mostro2 == "medium anxia")
            {
                warn.text = "Try to better follow the rhythm";
            }

            currentLineIndex++;
        }
        else
        {
            // Se il discorso è completo, passa alla scena 2
            SceneManager.LoadScene("UpDownAnsia"); // Assicurati che il nome della scena sia corretto
        }
        // Sostituisci con la frase che desideri visualizzare
        //string yourText = "Questa è la tua frase.";

        // Mostra la frase nella casella di testo
        //textField.text = yourText;
    }
}

// public void GestisciPulsante()
    // {
    //     contatorePulsanti++;
    //
    //     if (mostro1 == "small anxia")
    //     {
    //         Debug.Log(contatorePulsanti);
    //
    //         if (contatorePulsanti == 0)
    //         {
    //             heart1.gameObject.SetActive(true);
    //             layer1.gameObject.SetActive(true);
    //             heart2.gameObject.SetActive(true);
    //             layer2.gameObject.SetActive(true);
    //             heart3.gameObject.SetActive(true);
    //             layer3.gameObject.SetActive(true);
    //             contatorePulsanti++;
    //         }
    //         else if (contatorePulsanti == 2)
    //         {
    //             heart3.gameObject.SetActive(false);
    //             contatorePulsanti++;
    //         }
    //         else if (contatorePulsanti == 3)
    //         {
    //             gameover.gameObject.SetActive(true);
    //         }

            // case 1:
            //     heart1.SetActive(true);
            //     layer1.SetActive(true);
            //     heart2.SetActive(true);
            //     layer2.SetActive(true);
            //     heart3.SetActive(true);
            //     layer3.SetActive(true);
            //     break;
            //
            // case 2:
            //     heart3.SetActive(false);
            //     break;
            //
            // case 3:
            //     gameover.SetActive(true);
            //     break;
            //
            // // Aggiungi altri casi se necessario
            //
            // default:
            //     break;
        
    
    

