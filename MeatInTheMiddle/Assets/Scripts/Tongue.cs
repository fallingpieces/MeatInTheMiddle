using UnityEngine;

public class Tongue : MonoBehaviour
{
    [Header("Timing")]
    public float lingerDuration = 1f;

    [Header("Ammo")]
    public BeeSpawner beeSpawner;


    void Start()
    {
        // Auto find BeeSpawner if not assigned
        if (beeSpawner == null)
            beeSpawner = FindFirstObjectByType<BeeSpawner>();

        // Destroy after linger duration if no collision
        Invoke(nameof(DestroyTongue), lingerDuration);
    }

void OnTriggerEnter2D(Collider2D other)
{

     
    if (!other.CompareTag("Beehurtfrog")) return;


    Destroy(other.gameObject); // destroy the bee
    AddAmmoAndDestroy();       // add ammo and destroy tongue
}

    void AddAmmoAndDestroy()
    {
        if (beeSpawner != null)
            beeSpawner.AddAmmo(1);

        // Cancel the linger destroy since we're destroying now
        CancelInvoke(nameof(DestroyTongue));
        Destroy(gameObject);
    }

    void DestroyTongue()
    {
        Destroy(gameObject);
    }
}