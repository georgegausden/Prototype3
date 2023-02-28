using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float speed = 5f; // Speed of the sphere movement
    public float jumpForce = 10f; // Force of the sphere jump

    private bool isGrounded = true; // Flag to indicate if the sphere is grounded
    private Vector3 movement; // Vector to store the current movement direction

    // Update is called once per frame
    void Update()
    {
        // Get input from arrow keys
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Check if the player is moving
        bool isMoving = Mathf.Abs(horizontalInput) > 0f || Mathf.Abs(verticalInput) > 0f;

        // Calculate movement direction
        if (isMoving)
        {
            movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        }

        // Apply movement to the sphere
        transform.position += movement * speed * Time.deltaTime;

        // Check if the sphere is grounded
        if (isGrounded)
        {
            // Check if the user pressed the space bar
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Apply a jump force to the sphere
                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
    }

    // OnCollisionEnter is called when the sphere collides with another object
    void OnCollisionEnter(Collision other)
    {
        // Check if the sphere has collided with the ground
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
