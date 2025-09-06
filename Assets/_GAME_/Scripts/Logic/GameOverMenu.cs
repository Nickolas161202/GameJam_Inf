using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Esta função será chamada pelo botão "Reiniciar"
    public void ReiniciarJogo()
    {
        // Garante que o jogo não fique pausado se você usar Time.timeScale
        Time.timeScale = 1f;

        // Carrega o primeiro nível, que agora está no índice 1
        SceneManager.LoadScene(1);
    }

    // Esta função será chamada pelo botão "Menu Principal"
    public void VoltarAoMenu()
    {
        Time.timeScale = 1f;

        // Carrega o menu principal, que está no índice 0
        SceneManager.LoadScene(0);
    }

    // Esta função será chamada pelo botão "Sair"
    public void SairDoJogo()
    {
        // Escreve no console para sabermos que funcionou no Editor
        Debug.Log("Saindo do jogo...");

        // Fecha a aplicação (só funciona no jogo compilado, não no Editor da Unity)
        Application.Quit();
    }
}