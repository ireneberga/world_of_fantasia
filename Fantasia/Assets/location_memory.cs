using UnityEngine;

public class PlayerPositionManager : MonoBehaviour
{
    private static Vector3 playerPosition;

    void Start()
    {
        // Ensure there's only one instance of this script
        if (FindObjectsOfType<PlayerPositionManager>().Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public static void SavePlayerPosition(Vector3 position)
    {
        playerPosition = position;
        Debug.Log("Player position saved: " + playerPosition);
    }

    public static Vector3 GetSavedPlayerPosition()
    {
        Debug.Log("Player position retrieved: " + playerPosition);
        return playerPosition;
    }
}
