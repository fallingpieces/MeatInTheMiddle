using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject turretPrefab;

    [Header("Spawn Settings")]
    public Vector3 spawnOffset = Vector3.zero;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SpawnTurret();
        }
    }

    void SpawnTurret()
    {
        Instantiate(turretPrefab, transform.position + spawnOffset, Quaternion.identity);
    }
}