using UnityEngine;

public class WallMover : MonoBehaviour
{
    [HideInInspector] public float speed = 3f;
    [HideInInspector] public float vanishDistance = 10f;
    [HideInInspector] public float direction = 1f; // -1 = left, 1 = right

    private float startX;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x - startX) >= vanishDistance)
        {
            Destroy(gameObject);
        }
    }
}