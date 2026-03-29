using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal_P1");
        float y = Input.GetAxisRaw("Vertical_P1");
        Vector2 input = new Vector2(x, y).normalized;
        rb.linearVelocity = input * moveSpeed;

        animator.SetBool("isMoving", input.magnitude > 0);
    }
}