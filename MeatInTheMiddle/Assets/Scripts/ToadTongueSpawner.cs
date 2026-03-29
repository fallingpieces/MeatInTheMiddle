using UnityEngine;

public class ToadTongueSpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject tonguePrefab;

    [Header("Spawn Settings")]
    public float spawnDistance = 2f;
    public Vector2 spawnOffset = new Vector2(0f, 0f);

    [HideInInspector]
    public Vector2 facingDirection = Vector2.left;
    [HideInInspector]
    public bool isAttacking2 = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            SpawnTongue();
        }
    }

    void SpawnTongue()
    {
        isAttacking2 = true;
        Vector3 spawnPos = transform.position
            + (Vector3)(facingDirection.normalized * spawnDistance)
            + new Vector3(facingDirection.x * spawnOffset.x, spawnOffset.y, 0);
        Instantiate(tonguePrefab, spawnPos, Quaternion.identity);
        Invoke("ResetAttack", 0.3f);
    }

    void ResetAttack()
    {
        isAttacking2 = false;
    }
}