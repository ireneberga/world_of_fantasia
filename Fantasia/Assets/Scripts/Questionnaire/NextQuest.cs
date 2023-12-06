using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NextQuest : MonoBehaviour
{
    public GameObject objectToDeactivate;
    public GameObject objectToActivate;

    private void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    public void OnButtonClick()
    {
        // Deactivate the first object
        if (objectToDeactivate != null)
        {
            objectToDeactivate.SetActive(false);
        }

        // Activate the second object
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }
}
