using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class selection : MonoBehaviour
{
   
    
    public void tristezzagrande()
    {
        string mostro1 = "big sadness";

        // Salva il nome utente in un oggetto di gioco persistente
        PlayerPrefs.SetString("mostro1", mostro1);
        PlayerPrefs.Save();

        Debug.Log("mostro interiore " + mostro1);
    }
    
     public void tristezzamedia()
        {
            string mostro1 = "medium sadness";
    
            // Salva il nome utente in un oggetto di gioco persistente
            PlayerPrefs.SetString("mostro1", mostro1);
            PlayerPrefs.Save();
    
            Debug.Log("mostro interiore " + mostro1);
        }
    
    public void tristezzapiccola()
            {
                string mostro1 = "small sadness";
        
                // Salva il nome utente in un oggetto di gioco persistente
                PlayerPrefs.SetString("mostro1", mostro1);
                PlayerPrefs.Save();
        
                Debug.Log("mostro interiore " + mostro1);
            }
    
     public void ansiagrande()
                {
                    string mostro2 = "big anxia";
            
                    // Salva il nome utente in un oggetto di gioco persistente
                    PlayerPrefs.SetString("mostro2", mostro2);
                    PlayerPrefs.Save();
            
                    Debug.Log("mostro interiore " + mostro2);
                }
    
    public void ansiamedia()
                    {
                        string mostro2 = "medium anxia";
                
                        // Salva il nome utente in un oggetto di gioco persistente
                        PlayerPrefs.SetString("mostro2", mostro2);
                        PlayerPrefs.Save();
                
                        Debug.Log("mostro interiore " + mostro2);
                    }
    
     public void ansiapiccola()
                        {
                            string mostro2 = "small anxia";
                    
                            // Salva il nome utente in un oggetto di gioco persistente
                            PlayerPrefs.SetString("mostro2", mostro2);
                            PlayerPrefs.Save();
                    
                            Debug.Log("mostro interiore " + mostro2);
                        }
    
    public void insicurezzagrande()
                            {
                                string mostro3 = "high insecureness";
                        
                                // Salva il nome utente in un oggetto di gioco persistente
                                PlayerPrefs.SetString("mostro3", mostro3);
                                PlayerPrefs.Save();
                        
                                Debug.Log("mostro interiore " + mostro3);
                            }
    
     public void insicurezzamedia()
                                {
                                    string mostro3 = "medium insecureness";
                            
                                    // Salva il nome utente in un oggetto di gioco persistente
                                    PlayerPrefs.SetString("mostro3", mostro3);
                                    PlayerPrefs.Save();
                            
                                    Debug.Log("mostro interiore " + mostro3);
                                }
    
     public void insicurezzapiccola()
     {
         string mostro3 = "low insecureness";
                        
         // Salva il nome utente in un oggetto di gioco persistente
         PlayerPrefs.SetString("mostro3", mostro3);
         PlayerPrefs.Save();
                        
         Debug.Log("mostro interiore " + mostro3);
     }
     
     public void solitudinegrande()
                                {
                                    string mostro4 = "big loneliness";
                            
                                    // Salva il nome utente in un oggetto di gioco persistente
                                    PlayerPrefs.SetString("mostro4", mostro4);
                                    PlayerPrefs.Save();
                            
                                    Debug.Log("mostro interiore " + mostro4);
                                }
     
     public void solitudinemedia()
     {
         string mostro4 = "medium loneliness";
                            
         // Salva il nome utente in un oggetto di gioco persistente
         PlayerPrefs.SetString("mostro4", mostro4);
         PlayerPrefs.Save();
                            
         Debug.Log("mostro interiore " + mostro4);
     }
     
     public void solitudinepiccola()
     {
         string mostro4 = "small loneliness";
                            
         // Salva il nome utente in un oggetto di gioco persistente
         PlayerPrefs.SetString("mostro4", mostro4);
         PlayerPrefs.Save();
                            
         Debug.Log("mostro interiore " + mostro4);
     }
    
     public void CaricaScenaSuccessiva()
        {
            // Ottieni l'indice della scena corrente
            //int indiceScenaCorrente = SceneManager.GetActiveScene().buildIndex;
    
            // Carica la scena successiva nell'ordine delle scene
            SceneManager.LoadScene(3);
        }
    

  
}
