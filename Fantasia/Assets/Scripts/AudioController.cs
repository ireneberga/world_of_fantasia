using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip audioClip1; // Audio cammino sul terreno
    public AudioClip audioClip2; // Audio cammino sulle pozzanghere
    public AudioClip audioClip3; // Audio nuotare
    public AudioClip audioClip4; // Audio saltare
    private AudioSource _audioSource;
   
    public GameObject oggettoDaControllare;

    public int terrain;
    public int previousTerrain = 0;// Assegna l'oggetto da controllare
    
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.RightArrow))
        {
           
            if (oggettoDaControllare != null)
            {
                float coordinataY = oggettoDaControllare.transform.position.y;

                // In base al valore della coordinata y, scegli l'audio da riprodurre
                if (coordinataY > 101.45)
                {
                    
                    terrain = 0;
                }

                if (coordinataY < 101.45 && coordinataY > 100.6)
                {
                    
                    terrain = 1;
                }

                if (coordinataY <= 100.5)
                {
                    
                    terrain = 2;
                }
            }
        }

        if (terrain != previousTerrain)
        {
            previousTerrain = terrain;
            //cambia audioclip
            _audioSource.loop = true;
            if (terrain == 0)
            {
                PlayAudio(audioClip1);
            }
            else if (terrain == 1)
            {
                PlayAudio(audioClip2);
            }
            else
            {
                PlayAudio(audioClip3);
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
            Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            

            // Aggiungi il controllo sulla coordinata y dell'oggetto
            if (oggettoDaControllare != null)
            {
                float coordinataY = oggettoDaControllare.transform.position.y;

                // In base al valore della coordinata y, scegli l'audio da riprodurre
                if (coordinataY > 101.45)
                {
                    PlayAudio(audioClip1); // Riproduci il primo audio
                    
                }

                if (coordinataY < 101.45 && coordinataY > 100.6)
                {

                    PlayAudio(audioClip2); // Riproduci il secondo audio
                    
                }

                if (coordinataY <= 100.5)
                {
                    PlayAudio(audioClip3);
                    
                }
            }
        }
        
        
        // Verifica se il tasto è stato rilasciato
     if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) &&
        !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
      {
          StopAudio();
      }

     if (Input.GetKeyDown(KeyCode.E))
     {
         PlayAudio(audioClip4);
     }
    }
    

    void PlayAudio(AudioClip clip)
    {
        // Assicurati che l'AudioSource esista
        if (_audioSource != null)
        {
            // Assegna l'AudioClip all'AudioSource e riproduci l'audio
            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }

    void StopAudio()
    {
        // Interrompi l'audio
        if (_audioSource != null && _audioSource.isPlaying)
        {
            _audioSource.Stop();
        }
    }
    
}

