using UnityEngine;

public class BeeSpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject beePrefab;
    public TongueSpawner tongueSpawner;

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
        tongueSpawner = GetComponent<TongueSpawner>();
        rechargeTimer = rechargeTime;
        cooldownTimer = 0f;
    }

    void Update()
    {
        if (cooldownTimer > 0f)
            cooldownTimer -= Time.deltaTime;

        rechargeTimer -= Time.deltaTime;
        if (rechargeTimer <= 0f)
        {
            AddAmmo(1);
            rechargeTimer = rechargeTime;
        }

        if (Input.GetKeyDown(KeyCode.C) && cooldownTimer <= 0f)
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

        Vector3 spawnPos = transform.position + (Vector3)(tongueSpawner.facingDirection * 1.5f);
        GameObject bee = Instantiate(beePrefab, spawnPos, Quaternion.identity);

        BeeMover mover = bee.GetComponent<BeeMover>();
        if (mover == null)
        {
            Debug.LogError("BeeMover not found on bee prefab!");
            return;
        }

        mover.direction = tongueSpawner.facingDirection;
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