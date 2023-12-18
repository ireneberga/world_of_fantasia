using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class messageRespiration : MonoBehaviour
{
    public Text textField;
    public GameObject stratobianco;
   
    void Start()
    {
        stratobianco.gameObject.SetActive(true);
        textField.text = "Breath according to the cloud size and try to follow the Up and Down movement with the arrows of you keyboard";
        StartCoroutine(CancellaMessaggio());
        //textField.text = "You can pause, restart and end the game with the buttons in the left down corner";
        //StartCoroutine(CancellaMessaggio());
        //stratobianco.gameObject.SetActive(false);
        //textField.text = "";
    }
    
    IEnumerator CancellaMessaggio()
    {
        yield return new WaitForSeconds(9f);
        textField.text = "You can pause, restart and end the game with the buttons in the left down corner";
        yield return new WaitForSeconds(9f);
        textField.text = "";
        stratobianco.gameObject.SetActive(false);
        //stratobianco.gameObject.SetActive(false);
        //textField.text = "";
    }
    
}


