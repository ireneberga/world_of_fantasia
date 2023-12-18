using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TutorialManager : MonoBehaviour
{

    public TextMeshProUGUI middleText;

    void Start()
    {
        int tutorialFatto = PlayerPrefs.GetInt("tutorialDone", 0);
        if (tutorialFatto == 0)
        {
            StartCoroutine(ShowTutorial());
        }
    }

    IEnumerator ShowTutorial()
    {
        yield return new WaitForSeconds(1f);

        yield return ShowPrompt("Use your mouse to look around");

        yield return new WaitForSeconds(1f);

        yield return ShowPrompt("Use W, A, S, D to move");

        yield return new WaitForSeconds(1f);
        
        yield return ShowPrompt("Use space to jump");

        yield return new WaitForSeconds(1f);

        yield return ShowPrompt("Use Alt to run");

        yield return new WaitForSeconds(1f);
        yield return ShowPrompt("");
        PlayerPrefs.SetInt("tutorialDone", 1);
        middleText.gameObject.SetActive(true);

        // Add more steps as needed

        // Tutorial completed, you can do something here (e.g., hide UI, unlock player controls, etc.)
    }

    IEnumerator ShowPrompt(string message)
    {
        if (middleText != null)
        {
            middleText.text = message;

            // Activate the UI element
            middleText.gameObject.SetActive(true);

            // Wait for a few seconds
            yield return new WaitForSeconds(3f);

            // Deactivate the UI element
            middleText.gameObject.SetActive(false);
        }
    }
}