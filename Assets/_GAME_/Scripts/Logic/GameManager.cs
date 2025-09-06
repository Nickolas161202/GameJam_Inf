using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // A instância estática (Singleton)
    public static GameManager instance;

    void Awake()
    {
        // Lógica do Singleton
        if (instance == null)
        {
            // Se não houver nenhuma instância, esta se torna a instância
            instance = this;
            // E não é destruída ao carregar uma nova cena
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Se já existir uma instância (ex: ao voltar para a cena 1), esta é destruída
            Destroy(gameObject);
        }
    }

    // Esta é a função que será chamada quando o jogador morrer
    public void GameOver()
    {
        SceneManager.LoadScene(3); // Game over é cena 3
    }

    // Função bônus para ir para a próxima cena
    public void CarregarProximaCena()
    {
        // Pega o índice da cena atual
        int indiceCenaAtual = SceneManager.GetActiveScene().buildIndex;
        // Carrega a próxima cena da lista
        SceneManager.LoadScene(indiceCenaAtual + 1);
    }
}