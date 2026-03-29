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

        Vector2 input = new Vector2(x, y).normalized; // moved up here!

        if (input != Vector2.zero)
        {
            tongueSpawner.facingDirection = input;
            if (x != 0)
                sr.flipX = x > 0;
        }

        rb.linearVelocity = input * moveSpeed;
        animator.SetBool("isMoving2", input.magnitude > 0);
        if (tongueSpawner != null)
            animator.SetBool("isAttacking2", tongueSpawner.isAttacking2);
    }
}