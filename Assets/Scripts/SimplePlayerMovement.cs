using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;       // Player Movement speed
    public float jumpForce = 7f;   // How high the player jumps
    public float gravity = -20f;   // Gravity pull in game world

    private CharacterController controller;
    private Vector3 velocity;

    [Header("Ground Check Settings")]
    public float groundCheckDistance = 0.6f;  // Distance to check below player character 
    public LayerMask groundLayer;             // Set to "Ground" layer in Inspector for accuracy

    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (controller == null)
        {
            Debug.LogError("CharacterController component missing!");
        }

        // Ensure groundLayer is set to (default to Everything if none assigned)
        if (groundLayer == 0) groundLayer = ~0;
    }

    void Update()
    {
        // ==== Movement Input ====
        float x = 0f;
        float z = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) x = -1f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) x = 1f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) z = 1f;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) z = -1f;

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // ==== Ground Check ====
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Stick player to ground
        }

        // ==== Jump ====
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            Debug.Log("Jump applied!"); // Confirm jump triggers
        }

        // ==== Gravity ====
        velocity.y += gravity * Time.deltaTime;

        // Applying velocity to player
        controller.Move(velocity * Time.deltaTime);
    }
}