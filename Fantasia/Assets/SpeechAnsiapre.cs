using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpeechAnsiapre : MonoBehaviour
{
   public Text textField;
    //public Button showTextButton;
    private List<string>  speechLines;
    private int currentLineIndex = 0;
    
    private void InitializeSpeechLines()
    {
        // Inizializza la lista e aggiungi le tue linee di discorso
        speechLines = new List<string>();
        speechLines.Add("Now you have to fight your interiors monsters!");
        speechLines.Add("You will start fighting Anxia, and it's going to be as hard as the size of the monster you chose");
        speechLines.Add("In the following challenge you will enjoy a fly with me");
        speechLines.Add("Good Luck!");
       
        // Aggiungi ulteriori linee di discorso qui...
    }
    
    public void ShowTextOnClick()
    {
        // Controlla se ci sono ancora linee nel discorso
        if (currentLineIndex == 0)
        {
            InitializeSpeechLines();
            textField.text = speechLines[currentLineIndex];
            currentLineIndex++;
        }
        else if (currentLineIndex < speechLines.Count)
        {
            // Mostra la prossima linea del discorso
            textField.text = speechLines[currentLineIndex];
            currentLineIndex++;
        }
        else
        {
            // Se il discorso è completo, passa alla scena 2
            SceneManager.LoadScene(2); // Assicurati che il nome della scena sia corretto
        }
        // Sostituisci con la frase che desideri visualizzare
        //string yourText = "Questa è la tua frase.";

        // Mostra la frase nella casella di testo
        //textField.text = yourText;
    }
}
