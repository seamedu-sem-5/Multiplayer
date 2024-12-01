/* READ ME
 * This script controls player movement in a Photon multiplayer game,
 * handling input for walking, jumping, and camera rotation, and applies gravity.
 * It only processes input for the local player.
 */
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float mouseSensitivity = 100.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private float rotationY = 0.0f;
    private Camera _camera;

    PhotonView view;

    void Start()
    {
        _camera = GetComponentInChildren<Camera>();

        controller = GetComponent<CharacterController>();
        //Cursor.lockState = CursorLockMode.Locked; // Lock the cursor in the center of the screen
        view = GetComponent<PhotonView>();
        if (!view.IsMine)
        {
            Destroy(GetComponent<Rigidbody>());
            Destroy(_camera);
        }
    }

    void Update()
    {
        if (view.IsMine)
        {
            // Rotate the player based on mouse movement
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            rotationY += mouseX;
            transform.localRotation = Quaternion.Euler(0.0f, rotationY, 0.0f);

            if (controller.isGrounded)
            {
                // Get input for movement
                float moveHorizontal = Input.GetAxis("Horizontal");
                float moveVertical = Input.GetAxis("Vertical");

                // Calculate direction to move
                moveDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;

                // Jump
                if (Input.GetButton("Jump"))
                {
                    moveDirection.y = jumpSpeed;
                }
            }

            // Apply gravity
            moveDirection.y -= gravity * Time.deltaTime;

            // Move the controller
            controller.Move(moveDirection * Time.deltaTime);
        }
    }
}
