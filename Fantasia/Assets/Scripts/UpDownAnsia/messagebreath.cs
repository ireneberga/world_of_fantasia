using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class messagebreath : MonoBehaviour
{
    public Text textField;
    
    void Start()
    {
        StartCoroutine(StartWithDelay());
    }
    
    IEnumerator StartWithDelay()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(ComandiRespirazione());
    }
    
    IEnumerator ComandiRespirazione()
    {
        while (true)
        {
            yield return espira();
            yield return hold();
            yield return inspira();
            yield return hold();
            
           
        }
    }

    IEnumerator hold()
    {
        float startTime = Time.time;

        while (Time.time - startTime < 2f)
        {
            textField.text = "HOLD IN";
            yield return null;
        }
    }
    IEnumerator inspira()
    {
        float startTime = Time.time;

        while (Time.time - startTime < 4f)
        {
            textField.text = "BREATH IN";
            yield return null;
        }
    }
    
    IEnumerator espira()
    {
        float startTime = Time.time;

        while (Time.time - startTime < 4f)
        {
            textField.text = "BREATH OUT";
            yield return null;
        }
    }
}
