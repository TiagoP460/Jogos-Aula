using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se foi o Player que tocou na moeda
        if (other.CompareTag("Player"))
        {
            // --- A MUDANÇA ESTÁ AQUI ---
            // Avisa ao GameManager para somar +1 na contagem
            if (GameManager.instance != null)
            {
                GameManager.instance.ColetarMoeda();
            }
            else
            {
                Debug.LogError("ERRO: Não encontrei o GameManager na cena!");
            }
            // ---------------------------

            // Destrói a moeda (ela some da tela)
            Destroy(gameObject);
        }
    }
}