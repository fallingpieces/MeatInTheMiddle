using UnityEngine;

public class TongueSpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject tonguePrefab;

    [Header("Spawn Settings")]
    public float spawnDistance = 2f;
    public Vector2 facingDirection = Vector2.right; // set this from wherever you handle movement

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            SpawnTongue();
        }
    }

    void SpawnTongue()
    {
        Vector3 spawnPos = transform.position + (Vector3)(facingDirection.normalized * spawnDistance);
        Instantiate(tonguePrefab, spawnPos, Quaternion.identity);
    }
}