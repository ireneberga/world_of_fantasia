using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public string sceneToLoad = "Introduction";

    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}

