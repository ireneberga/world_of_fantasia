using UnityEngine;
using Dreamteck.Splines;

public class SplineCreator : MonoBehaviour
{
    void Start()
    {
        // Add a Spline Computer component to this object
        SplineComputer spline = gameObject.AddComponent<SplineComputer>();

        // Create a new array of spline points
        SplinePoint[] points = new SplinePoint[5];

        // Set each point's properties
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = new SplinePoint();
            points[i].position = Vector3.forward * i;
            points[i].normal = Vector3.up;
            points[i].size = 1f;
            points[i].color = Color.white;
        }

        // Write the points to the spline
        spline.SetPoints(points);
        
        // Make the object persist through scene changes
        DontDestroyOnLoad(gameObject);
    }
}

