using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider mySlider;
    public float totalTimeToCoverSlider = 4f;

    private float changeSpeed;

    void Start()
    {
        // Calcola la velocità di cambiamento in base al tempo desiderato
        changeSpeed = (mySlider.maxValue - mySlider.minValue) / totalTimeToCoverSlider;
    }
    

    void Update()
    {
        // Incrementa il valore dello slider quando premi e mantieni premuto il tasto freccia su
        if (Input.GetKey(KeyCode.UpArrow))
        {
            mySlider.value = Mathf.Min(mySlider.value + changeSpeed * Time.deltaTime, mySlider.maxValue);
        }

        // Decrementa il valore dello slider quando premi e mantieni premuto il tasto freccia giù
        if (Input.GetKey(KeyCode.DownArrow))
        {
            mySlider.value = Mathf.Max(mySlider.value - changeSpeed * Time.deltaTime, mySlider.minValue);
        }
    }
}

