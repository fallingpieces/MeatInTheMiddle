using UnityEngine;

public class ToadTongueSpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject tonguePrefab;

    [Header("Spawn Settings")]
    public float spawnDistance = 2f;
    public Vector2 facingDirection = Vector2.left; // set this from wherever you handle movement

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
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