using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonsOptions : MonoBehaviour
{
    private bool isPausato = false;
    public AudioSource meditazione;
    private float volumeOriginale;
    
    void Start()
    {
        
        //meditazione = GetComponent<AudioSource>();

        // Salva il volume originale
        volumeOriginale = meditazione.volume;
    }
    
    public void Termina()
    {
        SceneManager.LoadScene("postAnsia");
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
        meditazione.volume = 0f;
        isPausato = true;
    }

    void RiprendiGioco()
    {
        Time.timeScale = 1f; // Ripristina la scala del tempo a 1 per riprendere la scena
        meditazione.volume = volumeOriginale;
        isPausato = false;
    }
}
