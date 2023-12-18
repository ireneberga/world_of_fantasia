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
    }

    IEnumerator ShowPrompt(string message)
    {
        if (middleText != null)
        {
            middleText.text = message;
            middleText.gameObject.SetActive(true);

            yield return new WaitForSeconds(3f);

            middleText.gameObject.SetActive(false);
        }
    }
}