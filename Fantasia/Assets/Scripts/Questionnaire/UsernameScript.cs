using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UsernameScript : MonoBehaviour
{
    public TMP_InputField inputField;

    public void SaveUsernameToPlayerPrefs()
    {
        if (inputField != null)
        {
            string userInput = inputField.text;

            if (!string.IsNullOrEmpty(userInput))
            {
                PlayerPrefs.SetString("Username", userInput);
                Debug.Log("Username saved: "+ userInput);
            }
            else
            {
                Debug.LogWarning("Input is empty. Nothing saved.");
            }
        }
        else
        {
            Debug.LogError("InputField reference is not set in the inspector.");
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
