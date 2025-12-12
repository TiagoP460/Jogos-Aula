using UnityEngine;
using UnityEngine.UI; 

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    private Rigidbody2D rb;

    [Header("Interface")]
    public Image barraDeVidaImagem; 

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        
        // Garante que a barra comece cheia
        AtualizarBarraDeVida();
    }

    public void TakeDamage(float damage, Vector2 knockbackDirection, float knockbackForce = 10f)
    {
        currentHealth -= damage;
        // Debug.Log("Player levou dano! Vida atual: " + currentHealth);

        // Aplica knockback
        if (rb != null)
        {
             rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
        }

        // Verifica se morreu
        if (currentHealth <= 0)
        {
            currentHealth = 0; // Para não ficar negativo na barra
            Die();
        }

        // Atualiza a barra visualmente
        AtualizarBarraDeVida();
    }

    void AtualizarBarraDeVida()
    {
        if (barraDeVidaImagem != null)
        {
            barraDeVidaImagem.fillAmount = currentHealth / maxHealth;
        }
    }

    void Die()
    {
        Debug.Log("Player morreu!");

        // --- AQUI ESTÁ A MUDANÇA ---
        // Chama o GameManager para mostrar a tela de Game Over
        if (GameManager.instance != null)
        {
            GameManager.instance.GameOver();
        }
        // ---------------------------

        gameObject.SetActive(false); // Desativa o player
    }
}