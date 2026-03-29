using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private TongueSpawner tongueSpawner;
    private Animator animator;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tongueSpawner = GetComponent<TongueSpawner>();
        tongueSpawner.facingDirection = Vector2.right;
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal_P1");
        float y = Input.GetAxisRaw("Vertical_P1");

        Vector2 input = new Vector2(x, y).normalized;
        rb.linearVelocity = input * moveSpeed;

        // Update facing direction whenever moving in any direction
        if (input != Vector2.zero)
        {
            tongueSpawner.facingDirection = input;
            sr.flipX = x < 0;
        }

        animator.SetBool("isMoving1", input.magnitude > 0);
        if (tongueSpawner != null)
            animator.SetBool("isAttacking1", tongueSpawner.isAttacking1);
    }
}