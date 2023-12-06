using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceScript : MonoBehaviour
{
    public GameObject TextBox;
    public GameObject Choice01;
    public GameObject Choice02;
    public GameObject Choice03;
    public GameObject Choice04;
    public int choiceMade;

    public void ChoiceOption1 ()
    {
        TextBox.GetComponent<Text>().text = "Good job 1";
        choiceMade = 1;
    }

    public void ChoiceOption2 ()
    {
        TextBox.GetComponent<Text>().text = "Good job 2";
        choiceMade = 2;
    }

    public void ChoiceOption3 ()
    {
        TextBox.GetComponent<Text>().text = "Good job 3";
        choiceMade = 3;
    }

    public void ChoiceOption4 ()
    {
        TextBox.GetComponent<Text>().text = "Good job 4";
        choiceMade = 1;
    }


    void Update ()
    {
        if (choiceMade >= 1){
            Choice01.SetActive(false);
            Choice02.SetActive(false);
            Choice03.SetActive(false);
        }
    }
}
