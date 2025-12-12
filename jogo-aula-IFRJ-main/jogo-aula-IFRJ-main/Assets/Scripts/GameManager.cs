using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para reiniciar a fase
using UnityEngine.UI; // Necessário se usar UI padrão

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Cria uma referência global

    [Header("Configurações da UI")]
    public GameObject painelGameOver;
    public GameObject painelVitoria;

    [Header("Configurações de Jogo")]
    public int moedasColetadas = 0;
    public int totalMoedasParaGanhar = 10; // Defina quantas moedas existem na fase

    void Awake()
    {
        // Garante que só exista um GameManager e permite acesso fácil
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    // Chama isso quando o jogador morre
    public void GameOver()
    {
        painelGameOver.SetActive(true); // Mostra a tela de morte
        Time.timeScale = 0; // Pausa o jogo
    }

    // Chama isso quando coletar uma moeda
    public void ColetarMoeda()
    {
        moedasColetadas++;
        
        // Verifica se pegou todas
        if (moedasColetadas >= totalMoedasParaGanhar)
        {
            Vitoria();
        }
    }

    public void Vitoria()
    {
        painelVitoria.SetActive(true); // Mostra a tela de vitória
        Time.timeScale = 0; // Pausa o jogo
    }

    // Função para o botão "Recomeçar"
    public void RecomecarJogo()
    {
        Time.timeScale = 1; // Despausa o jogo antes de recomeçar!
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarrega a cena atual
    }
}