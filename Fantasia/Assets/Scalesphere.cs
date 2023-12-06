using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scalesphere : MonoBehaviour
{
    public float durataAllargamento = 3.8f;
    public float durataRiduzione = 3.8f;

    private float tempoTrascorso = 0f;
    private bool allargamentoInCorso = true;

    void Update()
    {
        tempoTrascorso += Time.deltaTime;

        if (tempoTrascorso <= durataAllargamento && allargamentoInCorso)
        {
            // Allargamento della sfera
            float scala = Mathf.Lerp(1f, 2f, tempoTrascorso / durataAllargamento);
            transform.localScale = new Vector3(scala, scala, scala);
        }
        else if (tempoTrascorso <= durataAllargamento + durataRiduzione)
        {
            // Riduzione della sfera
            float scala = Mathf.Lerp(2f, 1f, (tempoTrascorso - durataAllargamento) / durataRiduzione);
            transform.localScale = new Vector3(scala, scala, scala);
            allargamentoInCorso = false;
        }
        else
        {
            // Reset del tempo trascorso per ripetere l'animazione
            tempoTrascorso = 0f;
            allargamentoInCorso = true;
        }
    }
}
