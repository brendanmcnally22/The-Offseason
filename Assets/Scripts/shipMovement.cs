using UnityEngine;

public class shipMovement : MonoBehaviour
{
    public float thrustForce = 10f;
    public float rotationSpeed = 5f; // Mouse sensitivity
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody found on the ship!");
        }

        // Optional: Lock cursor to the screen center
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Mouse rotation
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseX * rotationSpeed);

        // Apply forward thrust
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * thrustForce);
        }

        // Stop the ship
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}

