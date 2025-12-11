using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Configurações de Vida")]
    public float maxHealth = 100f;
    private float currentHealth;

    [Header("Efeitos")]
    public GameObject deathEffect; // Opcional: Arraste uma partícula de explosão aqui se tiver

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Inimigo tomou dano! Vida atual: " + currentHealth);

        // Animação de dano (opcional)
        // GetComponent<Animator>().SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Inimigo Morreu!");
        
        // Efeito de morte (opcional)
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        // Destrói o objeto do inimigo
        Destroy(gameObject);
    }
}