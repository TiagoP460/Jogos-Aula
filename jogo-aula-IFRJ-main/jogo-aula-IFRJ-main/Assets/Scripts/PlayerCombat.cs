using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Configurações de Ataque")]
    public Transform attackPoint; // O ponto de onde sai o ataque (veja passo 3)
    public float attackRange = 0.5f; // Tamanho da área do ataque
    public LayerMask enemyLayers; // Para definir o que é inimigo
    public float attackDamage = 40f;
    public float attackRate = 2f; // Quantos ataques por segundo
    private float nextAttackTime = 0f;

    void Update()
    {
        // Verifica se apertou o botão de ataque (ex: botão esquerdo do mouse ou Tecla Z)
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Z))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        // 1. Tocar animação de ataque (se tiver)
        // GetComponent<Animator>().SetTrigger("Attack");

        // 2. Detectar inimigos na área de alcance
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // 3. Causar dano neles
        foreach(Collider2D enemy in hitEnemies)
        {
            // Tenta pegar o script de vida do inimigo
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
            }
        }
    }

    // Desenha a bolinha vermelha no editor para você ver o alcance do ataque
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}