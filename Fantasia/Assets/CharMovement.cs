using System.Collections;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float leftRightSpeed = 4f;

    void Start()
    {
        StartCoroutine(MuoviPersonaggio());
    }

    IEnumerator MuoviPersonaggio()
    {
        while (true)
        {
            yield return MoveInDirection(Vector3.left);
            yield return MoveStraight(Vector3.forward);
            yield return MoveInDirection(Vector3.right);
            yield return MoveStraight(Vector3.forward);
        }
    }

    IEnumerator MoveInDirection(Vector3 direction)
    {
        float startTime = Time.time;

        while (Time.time - startTime < 3.8f)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
            transform.Translate(direction * Time.deltaTime * leftRightSpeed);
                yield return null;
        }
    }

    IEnumerator MoveStraight(Vector3 direction)
    {
        float startTime = Time.time;

        while (Time.time - startTime < 2.0f)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
            yield return null;
        }
    }
}