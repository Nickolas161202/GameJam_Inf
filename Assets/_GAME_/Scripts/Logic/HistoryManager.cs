using UnityEngine;
using UnityEngine.UI; // Para o painel de diálogo (se você usou Image)
using TMPro; // Para o TextMeshPro
using UnityEngine.SceneManagement; // Para carregar a próxima cena

public class HistoryManager : MonoBehaviour
{
    [Header("Configurações do Diálogo")]
    public string[] falasHistoria; // Array de strings para cada linha de diálogo
    public float tempoEntreLetras = 0.05f; // Velocidade de digitação do texto

    [Header("Referências da UI")]
    public GameObject painelDialogo; // Arraste seu PainelDialogo aqui
    public TextMeshProUGUI textoHistoria; // Arraste seu TextoHistoria aqui
    public TextMeshProUGUI textoAvancar; // Arraste seu TextoAvancar aqui

    private int falaAtualIndex = 0;
    private bool digitando = false; // Flag para saber se o texto está sendo digitado
    private bool mostrandoRegras = false;
    [Header("Regras/Tutorial")]
    [TextArea]
    public string textoRegras;

    void Start()
    {
        // Certifica que todos os elementos estão visíveis no início
        painelDialogo.SetActive(true);
        textoAvancar.gameObject.SetActive(false); // Esconde o indicador de avanço no início
        
        // Inicia a primeira fala
        MostrarProximaFala();
    }

    void Update()
    {
        // Detecta o clique do mouse (ou toque na tela) para avançar
        if (Input.GetMouseButtonDown(0)) // 0 para botão esquerdo do mouse
        {
            if (digitando)
            {
                StopAllCoroutines();
                textoHistoria.text = falasHistoria[falaAtualIndex -1];
                digitando = false;
                textoAvancar.gameObject.SetActive(true);
            }
            else if (mostrandoRegras)
            {
                // Clique para iniciar o jogo
                IniciarJogo();
            }
            else
            {
                MostrarProximaFala();
            }
        }
    }

    void MostrarProximaFala()
    {
        // Se ainda houver falas na lista
        if (falaAtualIndex < falasHistoria.Length)
        {
            textoAvancar.gameObject.SetActive(false);
            StartCoroutine(DigitarTexto(falasHistoria[falaAtualIndex]));
            falaAtualIndex++;
        }
        else
        {
            // Fim da história, mostrar regras/tutorial
            MostrarRegrasOuTutorial();
        }
    }

    System.Collections.IEnumerator DigitarTexto(string fala)
    {
        digitando = true;
        textoHistoria.text = ""; // Limpa o texto antes de digitar o novo
        foreach (char letra in fala.ToCharArray())
        {
            textoHistoria.text += letra;
            yield return new WaitForSeconds(tempoEntreLetras);
        }
        digitando = false;
        textoAvancar.gameObject.SetActive(true); // Mostra o indicador após terminar de digitar
    }

    void MostrarRegrasOuTutorial()
    {
        mostrandoRegras = true;
        // Redimensiona o painel se necessário (exemplo: aumenta altura)
        RectTransform painelRect = painelDialogo.GetComponent<RectTransform>();
        if (painelRect != null)
        {
            painelRect.sizeDelta = new Vector2(painelRect.sizeDelta.x, -80); // ajuste conforme necessário
        }
        textoHistoria.text = textoRegras;
        textoHistoria.alignment = TextAlignmentOptions.Midline;
        textoAvancar.gameObject.SetActive(true);
        textoAvancar.text = "";
    }

    void IniciarJogo()
    {
        Debug.Log("Iniciando o jogo!");
        SceneManager.LoadScene("Game Scene");
    }
}