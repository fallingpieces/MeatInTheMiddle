using UnityEngine;

public class BeeSpawnerTurret : MonoBehaviour
{

    [Header("References")]
    public GameObject beePrefab;

    [Header("Bee Settings")]
    public float beeSpeed = 8f;
    public float vanishDistance = 10f;
    public Vector2 shootDirection = Vector2.right;

    [Header("Timing")]
    public float activeDuration = 3f;
    public float fireRate = 0.5f;

    private float activeTimer;
    private float fireTimer;

    void Start()
    {
        activeTimer = activeDuration;
    }

void Update()
{
    activeTimer -= Time.deltaTime;
    if (activeTimer <= 0f)
    {
        Destroy(gameObject);
        return;
    }

    fireTimer -= Time.deltaTime;
    if (fireTimer <= 0f)
    {
        Fire(shootDirection); // pass its own direction
        fireTimer = fireRate;
    }
}

public void Fire(Vector2 direction)
    {
        GameObject bee = Instantiate(beePrefab, transform.position, Quaternion.identity);
        BeeMover mover = bee.GetComponent<BeeMover>();
        mover.direction = shootDirection.normalized;
        mover.speed = beeSpeed;
        mover.vanishDistance = vanishDistance;
    }
}

