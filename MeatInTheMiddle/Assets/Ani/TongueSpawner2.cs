using UnityEngine;

public class TongueSpawner2 : MonoBehaviour
{
    [Header("References")]
    public GameObject tonguePrefab;

    [Header("Spawn Settings")]
    public float spawnDistance = 2f;
    public Vector2 facingDirection = Vector2.right;

    [HideInInspector]
    public bool isAttacking2 = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            SpawnTongue();
        }
    }

    void SpawnTongue()
    {
        isAttacking2 = true;
        Vector3 spawnPos = transform.position + (Vector3)(facingDirection.normalized * spawnDistance);
        Instantiate(tonguePrefab, spawnPos, Quaternion.identity);

        Invoke("ResetAttack", 0.3f);
    }

    void ResetAttack()
    {
        isAttacking2 = false;
    }
}