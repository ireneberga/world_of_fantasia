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
        yield return new WaitForSeconds(2f);
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
            textField.text = "hold in";
            yield return null;
        }
    }
    IEnumerator inspira()
    {
        float startTime = Time.time;

        while (Time.time - startTime < 4f)
        {
            textField.text = "breath in";
            yield return null;
        }
    }
    
    IEnumerator espira()
    {
        float startTime = Time.time;

        while (Time.time - startTime < 4f)
        {
            textField.text = "breath out";
            yield return null;
        }
    }
}
