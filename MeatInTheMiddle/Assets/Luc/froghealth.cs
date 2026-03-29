using UnityEngine;
using UnityEngine.SceneManagement;

public class FrogHealth : MonoBehaviour
{
    public int maxHealth = 2;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Damage from Bee
        if (other.CompareTag("Beehurtfrog"))
        {
            TakeDamage(1);
        }

        // Collect Meat (increase max health)
        if (other.CompareTag("meat"))
        {
            maxHealth++;
            currentHealth = maxHealth;

            // Optional: remove the meat after pickup
            Destroy(other.gameObject);
        }
    }

   void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
           
            GameManager.Instance.FrogDied();
            
        }
    }
}