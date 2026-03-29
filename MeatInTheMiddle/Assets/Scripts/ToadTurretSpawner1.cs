using UnityEngine;

public class ToadTurretSpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject turretPrefab;

    [Header("Spawn Settings")]
    public Vector3 spawnOffset = Vector3.zero;

    private bool canSpawn = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1) && canSpawn)
        {
            SpawnTurret();
        }
    }

    void SpawnTurret()
    {
        Instantiate(turretPrefab, transform.position + spawnOffset, Quaternion.identity);
        canSpawn = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("meat"))
        {
            canSpawn = true;
            Destroy(other.gameObject); // remove the meat object on pickup
        }
    }
}