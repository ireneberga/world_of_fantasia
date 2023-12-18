using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement_Visualization : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 2f;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Player movement
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 move = transform.TransformDirection(moveDirection);

        characterController.Move(move * speed * Time.deltaTime);

        // Rotate the player horizontally
        transform.Rotate(Vector3.up * horizontal * rotationSpeed);
    }
}




