using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject coinPrefab;  // Prefab della moneta
    public int numberOfCoins = 100;  // Numero di monete da generare
    public Vector3 direction = Vector3.forward;  // Direzione in cui generare le monete

    private static float characterYOffset = 0f;
    private static float characterPeriod = 12f;  // Periodo di default

    void Start()
    {
        GenerateCoins();
    }

    public static void SetCharacterYOffsetAndPeriod(float yOffset, float period)
    {
        characterYOffset = yOffset;
        characterPeriod = period;
    }

    void GenerateCoins()
    {
        float distanceBetweenCoins = characterPeriod;

        for (int i = 0; i < numberOfCoins; i++)
        {
            // Aggiungi l'offset Y generato dalla funzione sinusoidale
            Vector3 coinPosition = new Vector3(-32.08f, characterYOffset , 13f) + direction * i * distanceBetweenCoins;
            GameObject coin = Instantiate(coinPrefab, coinPosition, Quaternion.identity);
            coin.transform.localScale = new Vector3(3f, 3f, 3f);
        }
    }
}