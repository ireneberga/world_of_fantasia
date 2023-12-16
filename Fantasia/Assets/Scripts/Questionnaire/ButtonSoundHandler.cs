using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundHandler : MonoBehaviour
{
    public AudioSource clickSound;

    void Start()
    {
        // Assuming the AudioSource is attached to the same GameObject
        clickSound = GetComponent<AudioSource>();

        // Find all buttons in the scene and attach the PlayClickSound method
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => PlayClickSound());
        }
    }

    void PlayClickSound()
    {
        // Play the click sound
        clickSound.Play();
    }
}

