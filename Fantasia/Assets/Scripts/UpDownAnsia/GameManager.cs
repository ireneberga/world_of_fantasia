using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject heart1, heart2, heart3, layer1, layer2, layer3;
    public GameObject gameOver;
    // public GameObject audioGameObject;
    // private AudioSource audioListener;

    public Text textField;
    public AudioSource meditazione;
    //private float volumeOriginale;

    public static int health;
    // Start is called before the first frame update
    
    private string mostro2 ;

    private int clust;
    
    private void Awake()
    {
        //clust = 0;
        clust = PlayerPrefs.GetInt("ClusterValue");

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
    }
    
    void Start()
    {
        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
        //audioListener = audioGameObject.GetComponent<AudioSource>();
        //AudioListener.volume = 1f;
        //volumeOriginale = meditazione.volume;
        Time.timeScale = 1f;
        meditazione.volume = 0.4f;
        
       

        if (mostro2 == "small anxia")
        {
            TranslateObject(heart1);
            TranslateObject(heart2);
            TranslateObject(heart3);
            TranslateObject(layer1);
            TranslateObject(layer2);
            TranslateObject(layer3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(health);
        switch (health)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                if (mostro2 == "small anxia")
                {
                    gameOver.gameObject.SetActive(true);
                    // AudioListener.volume = 0.0f;
                    // CharacterMovement.active = false;
                    // textField.text = "";
                    Time.timeScale = 0f;
                    meditazione.volume = 0f;
                }



                break;
        }
        
    }
    
    void TranslateObject(GameObject obj)
    {
        if (obj != null)
        {
            // Traslazione di 240 unità verso destra
            obj.transform.Translate(Vector3.right * 500f);
        }
        else
        {
            Debug.LogWarning("Oggetto non assegnato.");
        }
    }

   
    
}
