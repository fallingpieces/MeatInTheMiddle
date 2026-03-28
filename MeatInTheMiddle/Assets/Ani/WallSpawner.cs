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
    SpawnWallsOnSide(Mathf.Round((transform.position.x - spawnDistanceFromMeat) * 100f) / 100f, 1f);
    SpawnWallsOnSide(Mathf.Round((transform.position.x + spawnDistanceFromMeat) * 100f) / 100f, -1f);
}

void SpawnWallsOnSide(float spawnX, float direction)
{
    float slotSize = wallHeight + wallGap - 0.05f;
    List<float> slots = new List<float>();
    float current = minY + wallHeight / 2f;
    while (current <= maxY - wallHeight / 2f)
    {
        slots.Add(current);
        current += slotSize;
    }

    // Shuffle independently per side
    for (int i = slots.Count - 1; i > 0; i--)
    {
        int j = Random.Range(0, i + 1);
        float temp = slots[i];
        slots[i] = slots[j];
        slots[j] = temp;
    }

    int wallCount = Random.Range(minWallsPerSpawn, maxWallsPerSpawn + 1);
    int spawnCount = Mathf.Min(wallCount, slots.Count);

    for (int i = 0; i < spawnCount; i++)
    {
        float spawnY = Mathf.Round(slots[i] * 100f) / 100f;
        SpawnSingleWall(new Vector3(spawnX, spawnY, 0f), direction);
    }
}

void SpawnSingleWall(Vector3 position, float direction)
{
    GameObject wall = Instantiate(wallPrefab, position, Quaternion.identity);
    WallMover mover = wall.GetComponent<WallMover>();
    mover.speed = wallSpeed;
    mover.vanishDistance = vanishDistance;
    mover.direction = -direction;
}
}