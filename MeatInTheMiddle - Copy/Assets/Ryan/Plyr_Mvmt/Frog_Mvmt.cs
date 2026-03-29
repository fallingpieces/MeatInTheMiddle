using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal_P1");
        float y = Input.GetAxisRaw("Vertical_P1");
        rb.linearVelocity = new Vector2(x, y).normalized * moveSpeed;
    }
}