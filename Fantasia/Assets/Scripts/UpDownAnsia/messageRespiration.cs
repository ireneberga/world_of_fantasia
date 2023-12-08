
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class messageRespiration : MonoBehaviour
{
    public Text textField;
   
    void Start()
    {
        textField.text = "Breath according to the cloud size and try to follow the Up and Down movement with the arrows of you keyboard";
        StartCoroutine(CancellaMessaggio());
    }
    
    IEnumerator CancellaMessaggio()
    {
        yield return new WaitForSeconds(9f);
        textField.text = "";
    }
    
}


