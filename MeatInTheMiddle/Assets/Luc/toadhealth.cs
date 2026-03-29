using UnityEngine;
using UnityEngine.SceneManagement;

public class ToadHealth : MonoBehaviour
{
    public int maxHealth = 2;
    private int currentHealth;

    [Header("Damage Flash")]
    public float damageDuration = 0.5f;

    [Header("Low Health Pulse")]
    public float pulseSpeed = 3f;

    [Header("Death Delay")]
    public float deathDelay = 1f;

    private SpriteRenderer sr;
    private Animator animator;
    private bool isInvincible = false;
    private Color normalColor;
    private bool isPulsing = false;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        normalColor = sr.color;
    }

    void Update()
    {
        if (isPulsing && !isInvincible && !isDead)
        {
            float t = (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f;
            sr.color = Color.Lerp(normalColor, Color.red, t);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bee") && !isInvincible && !isDead)
        {
            TakeDamage(1);
        }

        if (other.CompareTag("meat") && !isDead)
        {
            maxHealth++;
            currentHealth = maxHealth;
            isPulsing = false;
            sr.color = normalColor;
            Destroy(other.gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        ShowDamageFlash();
        isPulsing = currentHealth <= 1;

        if (currentHealth <= 0)
        {
            isDead = true;
            isPulsing = false;
            isInvincible = true;
            sr.color = normalColor;
            animator.enabled = true;
            animator.SetBool("isDead2", true);
            Invoke("TriggerDeath", deathDelay);
        }
    }

    void TriggerDeath()
    {
        GameManager.Instance.ToadDied();
    }

    void ShowDamageFlash()
    {
        isInvincible = true;
        sr.color = Color.red;
        Invoke("ResetFlash", damageDuration);
    }

    void ResetFlash()
    {
        if (isDead) return;
        if (!isPulsing)
            sr.color = normalColor;
        isInvincible = false;
    }
}