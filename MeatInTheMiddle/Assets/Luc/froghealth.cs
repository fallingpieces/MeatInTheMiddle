using UnityEngine;
using UnityEngine.SceneManagement;
public class FrogHealth : MonoBehaviour
{
    public int maxHealth = 2;
    private int currentHealth;
    [Header("Damage Flash")]
    public Sprite damageSprite;
    public float damageDuration = 0.5f;
    [Header("Low Health Pulse")]
    public float pulseSpeed = 3f;
    [Header("Death Delay")]
    public float deathDelay = 1f;
    private Sprite normalSprite;
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
        normalSprite = sr.sprite;
        normalColor = sr.color;
        animator = GetComponent<Animator>();
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
        if (other.CompareTag("Beehurtfrog") && !isInvincible && !isDead)
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
        ShowDamageSprite();
        isPulsing = currentHealth <= 1;
        if (currentHealth <= 0)
        {
            isDead = true;
            isPulsing = false;
            isInvincible = true;
            animator.enabled = false;
            sr.color = Color.yellow; // turn yellow on death
            Invoke("TriggerDeath", deathDelay);
        }
    }
    void TriggerDeath()
    {
        GameManager.Instance.FrogDied();
    }
    void ShowDamageSprite()
    {
        isInvincible = true;
        animator.enabled = false;
        sr.color = Color.red;
        if (damageSprite != null)
            sr.sprite = damageSprite;
        Invoke("ResetSprite", damageDuration);
    }
    void ResetSprite()
    {
        if (isDead) return; // don't reset if dead
        sr.sprite = normalSprite;
        if (!isPulsing)
            sr.color = normalColor;
        animator.enabled = true;
        isInvincible = false;
    }
}