using UnityEngine;
using UnityEngine.UI; // Essencial para controlar elementos de UI como o Slider
using TMPro; // Essencial para controlar o TextMeshPro
using UnityEngine.SceneManagement; // Para reiniciar a cena

public class HealthTimer : MonoBehaviour
{
    [Header("Configurações do Timer")]
    public float startTime = 60f; // Tempo máximo em segundos
    private float currentTime;

    [Header("Referências da UI")]
    public TextMeshProUGUI timeText; // Arraste seu texto aqui

    void Start()
    {
        // Inicia o timer com o valor máximo
        currentTime = startTime;

    }

    void Update()
    {
        // Se o tempo ainda não acabou...
        if (currentTime > 0)
        {
            // Diminui o tempo a cada segundo
            currentTime -= Time.deltaTime;

            // Atualiza os elementos da UI
            timeText.text = currentTime.ToString("F2");
        }
        else // Se o tempo acabou...
        {
            currentTime = 0; // Garante que não fique negativo
            GameOver();
        }
    }

    void GameOver()
    {
        // Apenas para teste, mostra uma mensagem no Console
        Debug.Log("GAME OVER!");

        // Recarrega a cena atual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}