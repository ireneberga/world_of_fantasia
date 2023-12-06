using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
// using UnityEngine;
//
// public class TutorialGameManager : MonoBehaviour
// {
//     public static string mostro1 = " anxia";
//     public GameObject heart1, heart2, heart3, layer1, layer2, layer3;
//     public GameObject gameOver;
//     // public GameObject audioGameObject;
//     // private AudioSource audioListener;
//
//   
//
//     public static int health;
//     // Start is called before the first frame update
//     void Start()
//     {
//         health = 3;
//         heart1.gameObject.SetActive(true);
//         heart2.gameObject.SetActive(true);
//         heart3.gameObject.SetActive(true);
//         gameOver.gameObject.SetActive(false);
//         //audioListener = audioGameObject.GetComponent<AudioSource>();
//         //AudioListener.volume = 1f;
//         Time.timeScale = 1f;
//         
//        
//
//         if (mostro1 == "big anxia")
//         {
//             TranslateObject(heart1);
//             TranslateObject(heart2);
//             TranslateObject(heart3);
//             TranslateObject(layer1);
//             TranslateObject(layer2);
//             TranslateObject(layer3);
//         }
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//         Debug.Log(health);
//         switch (health)
//         {
//             case 3:
//                 heart1.gameObject.SetActive(true);
//                 heart2.gameObject.SetActive(true);
//                 heart3.gameObject.SetActive(true);
//                 break;
//             case 2:
//                 heart1.gameObject.SetActive(true);
//                 heart2.gameObject.SetActive(true);
//                 heart3.gameObject.SetActive(false);
//                 break;
//             case 1:
//                 heart1.gameObject.SetActive(true);
//                 heart2.gameObject.SetActive(false);
//                 heart3.gameObject.SetActive(false);
//                 break;
//             case 0:
//                 heart1.gameObject.SetActive(false);
//                 heart2.gameObject.SetActive(false);
//                 heart3.gameObject.SetActive(false);
//                 gameOver.gameObject.SetActive(true); 
//                 // AudioListener.volume = 0.0f;
//                 // CharacterMovement.active = false;
//                 // textField.text = "";
//                 Time.timeScale = 0f;
//                 
//             
//                 
//                 break;
//         }
//         
//     }
//     
//     void TranslateObject(GameObject obj)
//     {
//         if (obj != null)
//         {
//             // Traslazione di 240 unità verso destra
//             obj.transform.Translate(Vector3.right * 500f);
//         }
//         else
//         {
//             Debug.LogWarning("Oggetto non assegnato.");
//         }
//     }
//
//    
//     
// }
//
