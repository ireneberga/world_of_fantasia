using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RegistrationManager : MonoBehaviour
{
    public InputField usernameInput;
    public Button registerButton;
    public Button goToNextSceneButton;

    private void Start()
    {
        registerButton.onClick.AddListener(SaveUsername);
        goToNextSceneButton.onClick.AddListener(GoToNextScene);
    }

    void SaveUsername()
    {
        string username = usernameInput.text;

        // Salva il nome utente in un oggetto di gioco persistente
        PlayerPrefs.SetString("Username", username);
        PlayerPrefs.Save();

        Debug.Log("Username salvato: " + username);
    }

    void GoToNextScene()
    {
        // Vai alla scena successiva
        SceneManager.LoadScene("Scenes/Introduction");
    }
}