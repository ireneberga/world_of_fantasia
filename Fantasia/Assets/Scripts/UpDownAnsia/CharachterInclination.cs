using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float amplitude = 0.6f;
    public float period = 12f; // Periodo di 11.6 secondi
    //string mostro2 = PlayerPrefs.GetInt("mostro2", mostro2); 
    private bool flagerroredown = false; 
    private bool flagerroreup = false; 
    private bool flagwarn = false;
    private float tempoPremuto = 0f; // Tempo attuale che la freccia è stata premuta
    private float tempoNonPremuto = 0f;
    //private float tempoWarning = 0f;
    private int errore = 0; // Variabile errore
    private int opposto1 = 0;
    private int opposto2 = 0;
    public Text textField;
    public Text breathText;
    //public Vector3 posizioneDesiderata = new Vector3(-32.08f, 0f, 0-1.085f);
    //public Vector3 inclinazioneDesiderata = new Vector3(-0.5f, 93.507f, 0f);
    private string mostro2 ;

    private int clust;
    private float tempoIniziale;

    

    private void Awake()
        {
            // Assegna la posizione desiderata
            //transform.position = posizioneDesiderata;
            // Assegna l'inclinazione desiderata in gradi (asse Y)
            //transform.eulerAngles = inclinazioneDesiderata;
            
            
            
            //clust = 0;
            clust = PlayerPrefs.GetInt("ClusterValue");
            Debug.Log(clust + " clust awake mov");

            if (clust == 0)
            {
                mostro2 = "small anxia";
                
            }
            else if (clust == 1)
            {
                mostro2 = "medium anxia";
            }
            else
            {
                mostro2 = "big anxia";
            }
            
            Debug.Log(mostro2 + "awake mov");
            
            tempoIniziale = Time.time;
        }
    
   
   
        void Update()
        {
            // Azzeramento di Time.deltaTime
            //float deltaTimeAzzerato = Time.time - tempoIniziale;
            //if(active){
                if (mostro2 == "big anxia" | mostro2 == "medium anxia" | mostro2 == "small anxia")
                {
                    // Calcola l'offset basato sul tempo trascorso dall'inizio della scena
                    float offset = (2f * Mathf.PI / period) * (Time.time - tempoIniziale);
                    
                    // Calcola il movimento in avanti lungo l'asse Z
                    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);

                    // Calcola la posizione Y basata sulla funzione sinusoidale con fase modificata
                    float yOffset = amplitude * Mathf.Sin(offset - Mathf.PI / 2f);

                    // Calcola l'angolo dell'inclinazione basata sulla posizione Y
                    float tangent = amplitude * (2f * Mathf.PI / period) * Mathf.Cos(offset - Mathf.PI / 2f);

                    // Applica la trasformazione lungo l'asse Y
                    transform.position = new Vector3(transform.position.x, yOffset, transform.position.z);

                    // Calcola la rotazione basata sulla tangente
                    Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward + Vector3.up * tangent);

                    // Applica la rotazione al personaggio
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);

                    // Passa l'offset Y e il periodo alla classe CoinGenerator
                    //CoinGenerator.SetCharacterYOffsetAndPeriod(yOffset, period);
               // }
            }
            
            if (mostro2 == "medium anxia" | mostro2 == "small anxia")
            {
               Controllopressione();
            }
           
        }
        
       private void Controllopressione()
        {
            //yield return new WaitForSeconds(9f);
            // Otteniamo l'angolo di rotazione attorno all'asse x
            //float angoloX = transform.rotation.eulerAngles.x;
                  string testoCasella = breathText.text;
                  //tempoWarning = +Time.deltaTime;
                  Debug.Log(testoCasella);
                // Controlla se la freccia su è premuta
                if (Input.GetKey(KeyCode.UpArrow) ) //& angoloX < 0
                {
                    tempoPremuto += Time.deltaTime;
                    tempoNonPremuto = 0;
                    opposto2 = 0;
                    flagerroreup = true;
                    Debug.Log("Freccia su premuta per poco tempo!");

                    // Se la freccia è stata premuta per almeno 4 secondi, resetta il tempo e resetta l'errore
                    if (tempoPremuto >= 3.5f)
                    {
                        flagerroreup = false;
                        Debug.Log("Freccia su premuta con successo!");
                        if (tempoPremuto > 4.5f)
                        {
                            flagerroreup = true;
                            Debug.Log("Freccia su premuta troppo a lungo !");
                        }
                        
                        
                    }

                    if (testoCasella != "BREATH IN")  //testoCasella != "breath in"
                    {
                        opposto1++;

                        if (opposto1 > 200)
                        {
                            GameManager.health -= 1;
                            opposto1 = 0; 
                            textField.text = "Try to better follow the rythm!";
                            flagwarn = true;
                        }
                    }

                }
                else if (Input.GetKey(KeyCode.DownArrow)) // Controlla se la freccia giù è premuta   & angoloX > 0
                {
                    tempoPremuto += Time.deltaTime;
                    tempoNonPremuto = 0;
                    opposto1 = 0; 
                    flagerroredown = true;
                    Debug.Log("Freccia giù premuta per poco tempo!");

                    // Se la freccia è stata premuta per almeno 4 secondi, resetta il tempo e resetta l'errore
                    if (tempoPremuto >= 3.5)
                    {
                        flagerroredown = false;
                        Debug.Log("Freccia giù premuta con successo!");
                        if (tempoPremuto > 4.5)
                        {
                            flagerroredown = true;
                            Debug.Log("Freccia giù premuta troppo a lungo !");
                        }
                        
                        
                    }
                    
                    if (testoCasella != "BREATH OUT")   //testoCasella != "breath out"
                    {
                        opposto2++;

                        if (opposto2 > 200)
                        {
                            GameManager.health -= 1;
                            opposto2 = 0; 
                            textField.text = "Try to better follow the rythm!";
                            flagwarn = true; 
                        }
                    }
                }
                else
                {
                    tempoPremuto = 0f;
                    tempoNonPremuto += Time.deltaTime;

                    // Se la freccia non è premuta, incrementa l'errore
                    if (flagerroredown)
                    {
                        errore++;
                        flagerroredown = false;
                    }
                    
                    if (flagerroreup)
                    {
                        errore++;
                        flagerroreup = false;
                    }
                    
                }

                // Controlla se è passato troppo tempo senza premere una freccia e incrementa l'errore
                if (tempoNonPremuto >= 8f)
                {
                    tempoPremuto = 0f;
                    errore++;
                    Debug.Log("Tempo massimo superato senza premere una freccia!");
                }


                if (errore > 5)
                {
                    errore = 0;
                    // Chiama un metodo nell'altro script e passa il dato intero
                    GameManager.health -= 1;
                    
                    textField.text = "Try to better follow the rythm!";
                    flagwarn = true; 
                    Debug.Log("cerca di respirare a tempo");
                }

                if (flagwarn)
                {
                    StartCoroutine(CancellaMessaggio());
                    flagwarn = false;
                }
        }
        
        IEnumerator CancellaMessaggio()
        {
            yield return new WaitForSeconds(2f);
            textField.text = "";
        }
}


