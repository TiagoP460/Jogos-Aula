using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // Variável para controlar a animação
    private Animator anim;

    [Header("Configurações de Ataque")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float attackDamage = 40f;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;

    void Start()
    {
        // Pega o Animator automaticamente
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            // Se apertar Botão Esquerdo OU tecla Z
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Z))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        // 1. Toca a animação direto
        if (anim != null)
        {
            anim.SetTrigger("Punch");
        }

        // 2. Detecta inimigos (lógica de dano)
        if (attackPoint == null) return;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}