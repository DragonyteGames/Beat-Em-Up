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

        // Calculate the velocity for sideways movement
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        rb.velocity = movement;

        if(horizontalInput > 0 && facingRight)
        {
            Flip();
        }
        if(horizontalInput < 0 && !facingRight)
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
