
using UnityEngine;

public class HeartGenerator : MonoBehaviour
{
    public GameObject heartPrefab;  // Prefab della vita
    public int numberOfHearts = 3;  // Numero da generare
    public Vector3 direction = Vector3.right;  // Direzione in cui generare

    // Start is called before the first frame update
    void Start()
    {
        GenerateHearts();
    }

    void GenerateHearts()
    {
        float distanceBetweenHearts = 67f;

        for (int i = 1; i < numberOfHearts+1; i++)
        {
            // Aggiungi l'offset Y generato dalla funzione sinusoidale
            Vector3 heartsPosition = new Vector3(-316f, 133f, 0f) + direction * i * distanceBetweenHearts;
            GameObject heart = Instantiate(heartPrefab, heartsPosition, Quaternion.identity);
            // Rinomina l'oggetto heart aggiungendo il numero dell'iterazione
            heart.name = "heart" + i;
        }
    }
}
