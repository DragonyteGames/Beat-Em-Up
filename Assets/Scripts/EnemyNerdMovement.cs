using UnityEngine;

public class EnemyNerdMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    bool facingRight = true;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical"); // New line for vertical input

        // Calculate the velocity for movement
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed); // Changed y component to verticalInput
        rb.velocity = movement;

        if (horizontalInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && facingRight)
        {
            Flip();
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
