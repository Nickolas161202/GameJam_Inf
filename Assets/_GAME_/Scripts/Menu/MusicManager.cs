using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // A única instância estática do MusicManager
    public static MusicManager instance;

    private AudioSource audioSource;

    void Awake()
    {
        // --- Início do Padrão Singleton ---
        // Se já existe uma instância e não sou eu...
        if (instance != null && instance != this)
        {
            // ...destrua este GameObject. Isso impede duplicatas.
            Destroy(this.gameObject);
            return; // Encerra a execução do Awake.
        }
        else
        {
            // Caso contrário, eu sou a única instância.
            instance = this;
        }
        // --- Fim do Padrão Singleton ---

        // Torna este GameObject persistente entre as cenas.
        DontDestroyOnLoad(this.gameObject);

        // Obtém a referência do componente AudioSource.
        audioSource = GetComponent<AudioSource>();
    }

    public void SetMasterVolume(float volume)
    {
        // Garante que o volume esteja entre 0 e 1.
        AudioListener.volume = Mathf.Clamp01(volume);
    }

    // Você pode adicionar métodos públicos para controlar a música, se necessário
    public void ChangeMusic(AudioClip music)
    {
        if (audioSource.clip == music) return;
        audioSource.clip = music;
        audioSource.Play();
    }
}