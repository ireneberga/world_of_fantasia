using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MultipleTMProDropdownsHandler : MonoBehaviour
{
    public TMP_Dropdown dropdown1;
    public TMP_Dropdown dropdown2;
    public TMP_Dropdown dropdown3;
    public TMP_Dropdown dropdown4;
    public TMP_Dropdown dropdown5;
    public TMP_Dropdown dropdown6;

    public Button saveButton;

    public string selectedOption1;
    public string selectedOption2;
    public string selectedOption3;
    public string selectedOption4;
    public string selectedOption5;
    public string selectedOption6;

    void Start()
    {
        dropdown1.onValueChanged.AddListener(delegate { DropdownValueChanged(dropdown1, 1); });
        dropdown2.onValueChanged.AddListener(delegate { DropdownValueChanged(dropdown2, 2); });
        dropdown3.onValueChanged.AddListener(delegate { DropdownValueChanged(dropdown3, 3); });
        dropdown4.onValueChanged.AddListener(delegate { DropdownValueChanged(dropdown4, 4); });
        dropdown5.onValueChanged.AddListener(delegate { DropdownValueChanged(dropdown5, 5); });
        dropdown6.onValueChanged.AddListener(delegate { DropdownValueChanged(dropdown6, 6); });

        saveButton.onClick.AddListener(SaveButtonClicked);
    }

    void DropdownValueChanged(TMP_Dropdown change, int dropdownNumber)
    {
        string selectedOption = change.options[change.value].text;

        // Assign the selected option to the appropriate variable based on the dropdown number
        switch (dropdownNumber)
        {
            case 1:
                selectedOption1 = selectedOption;
                break;
            case 2:
                selectedOption2 = selectedOption;
                break;
            case 3:
                selectedOption3 = selectedOption;
                break;
            case 4:
                selectedOption4 = selectedOption;
                break;
            case 5:
                selectedOption5 = selectedOption;
                break;
            case 6:
                selectedOption6 = selectedOption;
                break;
        }
    }

    void SaveButtonClicked()
    {
        Debug.Log("Selected Options:");
        Debug.Log("Dropdown 1: " + selectedOption1);
        Debug.Log("Dropdown 2: " + selectedOption2);
        Debug.Log("Dropdown 3: " + selectedOption3);
        Debug.Log("Dropdown 4: " + selectedOption4);
        Debug.Log("Dropdown 5: " + selectedOption5);
        Debug.Log("Dropdown 6: " + selectedOption6);

        // You can now use the selected options as needed in your script
    }
}
