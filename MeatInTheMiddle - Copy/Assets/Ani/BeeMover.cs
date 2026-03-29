using UnityEngine;

public class BeeMover : MonoBehaviour
{

    [HideInInspector] public Vector2 direction;
    [HideInInspector] public float speed = 5f;
    [HideInInspector] public float vanishDistance = 10f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, startPos) >= vanishDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Ignore collision with the shooter itself
        if (other.CompareTag("Meat")) return;

        Destroy(gameObject);
    }
}

