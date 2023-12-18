using UnityEngine;

public class FogController : MonoBehaviour
{
    public float cluster0FogDensity = 0.03f;
    public float cluster1FogDensity = 0.02f;
    public float cluster2FogDensity = 0.01f;

    void Start()
    {
        int clusterValue = PlayerPrefs.GetInt("ClusterValue", 0);
        switch (clusterValue)
        {
            case 0:
                RenderSettings.fogDensity = cluster0FogDensity;
                break;
            case 1:
                RenderSettings.fogDensity = cluster1FogDensity;
                break;
            case 2:
                RenderSettings.fogDensity = cluster2FogDensity;
                break;
        }
        RenderSettings.fog = true;
    }
}