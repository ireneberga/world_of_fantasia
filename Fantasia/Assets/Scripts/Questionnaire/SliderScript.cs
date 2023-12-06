using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderAndTextController : MonoBehaviour
{
    public Slider mySlider;
    public TextMeshProUGUI myText;
    public Button saveButton;

    private void Start()
    {
        // Ensure all required components are assigned in the Unity Editor
        if (mySlider == null || myText == null || saveButton == null)
        {
            Debug.LogError("Assign all required components in the Unity Editor.");
            return;
        }

        // Set up the slider and text initial values
        mySlider.onValueChanged.AddListener(UpdateTextValue);
        saveButton.onClick.AddListener(SaveSliderValue);
    }

    private void UpdateTextValue(float value)
    {
        // Update the text with the current slider value
        myText.text = "" + value.ToString(); // Displaying the value with two decimal places
    }

    private void SaveSliderValue()
    {
        // Save the slider value or perform any other action when the button is clicked
        float sliderValue = mySlider.value;
        PlayerPrefs.SetFloat("Age", sliderValue); // Save the value using PlayerPrefs (you can use another method to save data)
        Debug.Log("Slider value saved: " + sliderValue);
    }
}

