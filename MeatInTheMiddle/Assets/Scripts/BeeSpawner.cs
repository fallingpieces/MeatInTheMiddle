using UnityEngine;

public class BeeSpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject beePrefab;
    public TongueSpawner tongueSpawner;

    [Header("Ammo")]
    public int maxAmmo = 5;
    public int currentAmmo;

    void Start()
    {
        //currentAmmo = 0;
        tongueSpawner = GetComponent<TongueSpawner>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
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

    Vector3 spawnPos = transform.position + (Vector3)(tongueSpawner.facingDirection * 1.5f);
    GameObject bee = Instantiate(beePrefab, spawnPos, Quaternion.identity);
    Debug.Log("Bee name: " + bee.name);
    Debug.Log("BeeMover exists: " + (bee.GetComponent<BeeMover>() != null));
    Debug.Log("Is bee active: " + bee.activeInHierarchy);

    BeeMover mover = bee.GetComponent<BeeMover>();
    if (mover == null)
    {
        Debug.LogError("BeeMover not found on bee prefab!");
        return;
    }

    mover.direction = tongueSpawner.facingDirection;
    mover.speed = 8f;
    mover.vanishDistance = 10f;

    currentAmmo--;
}

    public void AddAmmo(int amount)
    {
        currentAmmo = Mathf.Min(currentAmmo + amount, maxAmmo);
        Debug.Log("Ammo replenished! Current ammo: " + currentAmmo);
    }
}