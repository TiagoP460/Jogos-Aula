using UnityEngine;
using UnityEngine.UI; // <--- ADICIONADO: Necessário para controlar a interface (UI)

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    private Rigidbody2D rb;

    [Header("Interface")]
    // Mudamos de "HealthBar" (script) para "Image" (componente nativo do Unity)
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
        Debug.Log("Player levou dano! Vida atual: " + currentHealth);

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
        // Só tenta atualizar se você tiver arrastado a imagem no Inspector
        if (barraDeVidaImagem != null)
        {
            // O fillAmount vai de 0 a 1 (ex: 50 / 100 = 0.5, que é metade da barra)
            barraDeVidaImagem.fillAmount = currentHealth / maxHealth;
        }
    }

    void Die()
    {
        Debug.Log("Player morreu!");
        gameObject.SetActive(false);
    }
}