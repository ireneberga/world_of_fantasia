using UnityEngine;

public class AssignValuesAndSum : MonoBehaviour
{
    // Reference to the script handling dropdowns and saving selected options
    public MultipleTMProDropdownsHandler dropdownHandler1;
    public MultipleTMProDropdownsHandler dropdownHandler2;

    public int sum1;
    public int sum2;

    void Start()
    {
        // // Make sure the dropdownHandler reference is set
        // if (dropdownHandler1 == null || dropdownHandler2 == null)
        // {
        //     Debug.LogError("Dropdown handler reference is not set. Please assign it in the inspector.");
        //     return;
        // }

        // Call a method to assign values and calculate the sum when needed
        CalculateAndPrintSum();
    }

    void CalculateAndPrintSum()
    {
        // Assign numerical values based on the selected options
        int value1 = AssignValue(selectedOption: dropdownHandler1.selectedOption1);
        int value2 = AssignValue(selectedOption: dropdownHandler1.selectedOption2);
        int value3 = AssignValue(selectedOption: dropdownHandler1.selectedOption3);
        int value4 = AssignValue(selectedOption: dropdownHandler1.selectedOption4);
        int value5 = AssignValue(selectedOption: dropdownHandler1.selectedOption5);
        int value6 = AssignValue(selectedOption: dropdownHandler1.selectedOption6);

        int value7 = AssignValue(selectedOption: dropdownHandler2.selectedOption1);
        int value8 = AssignValue(selectedOption: dropdownHandler2.selectedOption2);
        int value9 = AssignValue(selectedOption: dropdownHandler2.selectedOption3);
        int value10 = AssignValue(selectedOption: dropdownHandler2.selectedOption4);
        int value11 = AssignValue(selectedOption: dropdownHandler2.selectedOption5);
        int value12 = AssignValue(selectedOption: dropdownHandler2.selectedOption6);

        // Sum all the values
        sum1 = value1 + value2 + value3 + value4 + value5 + value6;
        sum2 = value7 + value8 + value9 + value10 + value11 + value12;

        // Print the individual values and the sum to the console
        Debug.Log("Assigned Values:");
        Debug.Log("Dropdown 1: " + value1);
        Debug.Log("Dropdown 2: " + value2);
        Debug.Log("Dropdown 3: " + value3);
        Debug.Log("Dropdown 4: " + value4);
        Debug.Log("Dropdown 5: " + value5);
        Debug.Log("Dropdown 6: " + value6);
        Debug.Log("Sum1: " + sum1);
        Debug.Log("Sum2: " + sum2);
    }

    int AssignValue(string selectedOption)
    {
        // Assign numerical values based on the selected option
        switch (selectedOption)
        {
            case "Not at all":
                return 0;
            case "A little":
                return 1;
            case "Moderately":
                return 2;
            case "Quite a bit":
                return 3;
            case "Extremely":
                return 4;
            default:
                return 0; // Default to 0 if the selected option is not recognized
        }
    }
}

