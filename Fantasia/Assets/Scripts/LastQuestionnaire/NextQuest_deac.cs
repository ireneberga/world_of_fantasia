using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NextQuest_deac : MonoBehaviour
{
    public GameObject objectToActivate;
    public GameObject objectToDeActivate;

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
        // Activate the second object
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
        if (objectToDeActivate != null)
        {
            objectToDeActivate.SetActive(false);
        }
    }
}
