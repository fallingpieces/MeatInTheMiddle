using UnityEngine;

public class ToadBeeSpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject beePrefab;
    public ToadTongueSpawner tongueSpawner;

    [Header("Ammo")]
    public int maxAmmo = 5;
    public int currentAmmo;

    [Header("Timers")]
    public float rechargeTime = 2f;
    public float shootCooldown = 1f;

    private float rechargeTimer;
    private float cooldownTimer;

    void Start()
    {
        currentAmmo = 0;
        tongueSpawner = GetComponent<ToadTongueSpawner>();
        rechargeTimer = rechargeTime;
        cooldownTimer = 0f;
    }

    void Update()
    {
        // Count down cooldown
        if (cooldownTimer > 0f)
            cooldownTimer -= Time.deltaTime;

        // Count down recharge and add ammo
        rechargeTimer -= Time.deltaTime;
        if (rechargeTimer <= 0f)
        {
            AddAmmo(1);
            rechargeTimer = rechargeTime;
        }

        if (Input.GetKeyDown(KeyCode.Keypad2) && cooldownTimer <= 0f)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (currentAmmo <= 0)
        {
            Debug.Log("Out of ammo!");
            return;
        }

        Vector3 spawnPos = transform.position + (Vector3)(tongueSpawner.facingDirection * -1.5f);
        GameObject bee = Instantiate(beePrefab, spawnPos, Quaternion.identity);

        BeeMover mover = bee.GetComponent<BeeMover>();
        if (mover == null)
        {
            Debug.LogError("BeeMover not found on bee prefab!");
            return;
        }

        mover.direction = -tongueSpawner.facingDirection;
        mover.speed = 8f;
        mover.vanishDistance = 10f;

        currentAmmo--;
        cooldownTimer = shootCooldown;
        Debug.Log("Ammo remaining: " + currentAmmo);
    }

    public void AddAmmo(int amount)
    {
        currentAmmo = Mathf.Min(currentAmmo + amount, maxAmmo);
        Debug.Log("Ammo replenished! Current ammo: " + currentAmmo);
    }
}