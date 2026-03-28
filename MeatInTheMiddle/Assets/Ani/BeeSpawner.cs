using UnityEngine;

public class BeeSpawner : MonoBehaviour
{
<<<<<<< Updated upstream
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
=======
    [Header("References")]
    public GameObject beePrefab;

    [Header("Bee Settings")]
    public float beeSpeed = 8f;
    public float vanishDistance = 10f;

    [Header("Ammo")]
    public int maxAmmo = 3;
    public int currentAmmo;

    [Header("Direction")]
    public Vector2 shootDirection = Vector2.right; // change in inspector or set dynamically

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (currentAmmo <= 0)
        {
            Debug.Log("Out of ammo!");
            return;
        }

        GameObject bee = Instantiate(beePrefab, transform.position, Quaternion.identity);
        BeeMover mover = bee.GetComponent<BeeMover>();
        mover.direction = shootDirection.normalized;
        mover.speed = beeSpeed;
        mover.vanishDistance = vanishDistance;

        currentAmmo--;
        Debug.Log("Ammo remaining: " + currentAmmo);
    }

    // Called later by tongue collision
    public void AddAmmo(int amount)
    {
        currentAmmo = Mathf.Min(currentAmmo + amount, maxAmmo);
        Debug.Log("Ammo replenished! Current ammo: " + currentAmmo);
    }
}
>>>>>>> Stashed changes
