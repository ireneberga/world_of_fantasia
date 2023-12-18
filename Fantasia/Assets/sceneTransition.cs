using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeOnTrigger : MonoBehaviour
{   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Check if the entering object is the player
        {
            SceneManager.LoadScene("TutorialAnsia", LoadSceneMode.Single);
        }
    }
}