using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    private TongueSpawner tongueSpawner;

    private Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        tongueSpawner = GetComponent<TongueSpawner>();
        tongueSpawner.facingDirection = Vector2.right; // default direction

        animator = GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal_P1");
        float y = Input.GetAxisRaw("Vertical_P1");

        rb.linearVelocity = new Vector2(x, y).normalized * moveSpeed;

        // Only update facing direction when moving horizontally
        if (x != 0)
        {
            tongueSpawner.facingDirection = new Vector2(x, 0).normalized;
        }

        Vector2 input = new Vector2(x, y).normalized;
        rb.linearVelocity = input * moveSpeed;

        animator.SetBool("isMoving", input.magnitude > 0);

    }
}