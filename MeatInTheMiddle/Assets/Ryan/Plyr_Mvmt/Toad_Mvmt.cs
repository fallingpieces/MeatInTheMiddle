using UnityEngine;

public class ToadMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private ToadTongueSpawner tongueSpawner;
    private Animator animator;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tongueSpawner = GetComponent<ToadTongueSpawner>();
        tongueSpawner.facingDirection = Vector2.left; // toad faces left by default
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal_P2");
        float y = Input.GetAxisRaw("Vertical_P2");

        if (x != 0)
        {
            tongueSpawner.facingDirection = new Vector2(x, 0).normalized;
            sr.flipX = x > 0; // flip when moving right since toad naturally faces left
        }

        Vector2 input = new Vector2(x, y).normalized;
        rb.linearVelocity = input * moveSpeed;
        animator.SetBool("isMoving2", input.magnitude > 0);
        if (tongueSpawner != null)
            animator.SetBool("isAttacking2", tongueSpawner.isAttacking2);
    }
}