using UnityEngine;

public class DragonController : MonoBehaviour
{
    public Transform target; // Assign the target (player) in the Inspector
    public float rotationSpeed = 5f;
    public float hoverAmplitude = 0.5f;
    public float hoverSpeed = 2f;

    void Update()
    {
        // Point the dragon towards the target
        if (target != null)
        {
            Vector3 directionToTarget = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }

        // Fluctuate in the Y direction (hover)
        float hoverOffset = Mathf.Sin(Time.time * hoverSpeed) * hoverAmplitude;
        transform.position = new Vector3(transform.position.x, hoverOffset + 103, transform.position.z);
    }
}