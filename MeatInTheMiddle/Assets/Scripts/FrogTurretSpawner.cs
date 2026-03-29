using UnityEngine;

public class FrogTurretSpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject turretPrefab;

    [Header("Spawn Settings")]
    public Vector3 spawnOffset = Vector3.zero;

    [Header("Turret Ammo")]
    public int maxTurrets = 3;
    public int currentTurrets = 2; // start with 2

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && currentTurrets > 0)
        {
            SpawnTurret();
        }
    }

    void SpawnTurret()
    {
        Instantiate(turretPrefab, transform.position + spawnOffset, Quaternion.identity);
        currentTurrets--;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("meat"))
        {
            if (currentTurrets < maxTurrets)
            {
                currentTurrets++;
                Debug.Log("Meat picked up! Turrets: " + currentTurrets);
            }
            Destroy(other.gameObject);
        }
    }
}