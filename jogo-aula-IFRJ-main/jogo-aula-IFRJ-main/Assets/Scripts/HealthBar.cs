using UnityEngine;
using UnityEngine.UI; // Necessário para mexer com UI

public class HealthBar : MonoBehaviour
{
    private Image healthBarFill;

    void Start()
    {
        // Pega o componente de Imagem deste objeto automaticamente
        healthBarFill = GetComponent<Image>();
    }

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        // Calcula a porcentagem (0.0 a 1.0) e ajusta a barra
        healthBarFill.fillAmount = currentHealth / maxHealth;
    }
}