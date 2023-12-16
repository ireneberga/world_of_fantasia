using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonsOptions : MonoBehaviour
{
    private bool isPausato = false;
    
    public void Termina()
    {
        SceneManager.LoadScene("finalGameSpeech");
    }
    
    public void Rincomincia()
    {
        SceneManager.LoadScene("UpDownAnsia");
    }
    
    public void TogglePausa()
    {
        if (isPausato)
        {
            RiprendiGioco();
        }
        else
        {
            MettiInPausa();
        }
    }

    void MettiInPausa()
    {
        Time.timeScale = 0f; // Imposta la scala del tempo a 0 per mettere in pausa la scena
        isPausato = true;
    }

    void RiprendiGioco()
    {
        Time.timeScale = 1f; // Ripristina la scala del tempo a 1 per riprendere la scena
        isPausato = false;
    }
}
