using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    
    // public GameObject audioGameObject;
    // private AudioSource audioListener;
    public void restart()
    {
        // audioListener = audioGameObject.GetComponent<AudioSource>();
        // CharacterMovement.active = true;
        // AudioListener.volume = 0.7f;
        Time.timeScale = 1f;
        SceneManager.LoadScene("UpDownAnsia");
        
        
    }
}
