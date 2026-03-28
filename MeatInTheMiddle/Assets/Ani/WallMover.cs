using UnityEngine;

public class WallMover : MonoBehaviour
{
    [HideInInspector] public float speed = 5f;
    [HideInInspector] public float vanishDistance = 3f;
    
    private float startX;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (transform.position.x - startX >= vanishDistance)
        {
            Destroy(gameObject);
        }
    }
}