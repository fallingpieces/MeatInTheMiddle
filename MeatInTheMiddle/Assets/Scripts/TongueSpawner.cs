using UnityEngine;

public class TongueSpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject tonguePrefab;

    [Header("Spawn Settings")]
    public float spawnDistance = 2f;
    public Vector2 spawnOffset = new Vector2(0f, 0f);
    public float attackCooldown = 1f; // change in Inspector!

    [HideInInspector]
    public Vector2 facingDirection = Vector2.right;
    [HideInInspector]
    public bool isAttacking1 = false;

    private float lastAttackTime = -999f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && Time.time >= lastAttackTime + attackCooldown)
        {
            SpawnTongue();
        }
    }

    void SpawnTongue()
    {
        isAttacking1 = true;
        lastAttackTime = Time.time;
        Vector3 spawnPos = transform.position
            + (Vector3)(facingDirection.normalized * spawnDistance)
            + new Vector3(facingDirection.x * spawnOffset.x, spawnOffset.y, 0);
        GameObject tongue = Instantiate(tonguePrefab, spawnPos, Quaternion.identity);
        Invoke("ResetAttack", 0.3f);
    }

    void ResetAttack()
    {
        isAttacking1 = false;
    }
}