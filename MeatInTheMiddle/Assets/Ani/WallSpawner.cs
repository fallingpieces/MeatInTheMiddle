using UnityEngine;
using System.Collections.Generic;
public class WallSpawner : MonoBehaviour
{

    public GameObject wallPrefab;


    [Header("Spawning")]
    public float spawnInterval = 2f;
    public float spawnDistanceFromMeat = 10f;

    [Header("Wall Settings")]
    public float wallSpeed = 5f;
    public float vanishDistance = 15f;

    [Header("Vertical Randomness")]
    public float minY = -2f;
    public float maxY = 2f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnWall();
            timer = 0f;
        }
    }

[Header("Wall Count")]
public int minWallsPerSpawn = 2;
public int maxWallsPerSpawn = 3;
public float wallHeight = 1.5f;
public float wallGap = 0.5f; // extra gap between walls

void SpawnWall()
{
    int wallCount = Random.Range(minWallsPerSpawn, maxWallsPerSpawn + 1);

    float spawnX = transform.position.x + spawnDistanceFromMeat;
    float slotSize = wallHeight + wallGap-0.15f;

    // Build list of all available slot centers
    List<float> slots = new List<float>();
    float current = minY + wallHeight / 2f;
    while (current <= maxY - wallHeight / 2f)
    {
        slots.Add(current);
        current += slotSize;
    }

    // Shuffle the slots
    for (int i = slots.Count - 1; i > 0; i--)
    {
        int j = Random.Range(0, i + 1);
        float temp = slots[i];
        slots[i] = slots[j];
        slots[j] = temp;
    }

    // Pick the first N slots after shuffling
    int spawnCount = Mathf.Min(wallCount, slots.Count);
    for (int i = 0; i < spawnCount; i++)
    {
        // Small random offset within the slot so it feels natural
        float randomOffset = Random.Range(-wallGap / 2f, wallGap / 2f);
        float spawnY = slots[i] + randomOffset;

        Vector3 spawnPos = new Vector3(spawnX, spawnY, 0f);
        GameObject wall = Instantiate(wallPrefab, spawnPos, Quaternion.identity);

        WallMover mover = wall.GetComponent<WallMover>();
        mover.speed = wallSpeed;
        mover.vanishDistance = vanishDistance;
    }
}
}