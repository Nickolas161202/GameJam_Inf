using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing;


public class Settings : MonoBehaviour
{

    // 2. Inicialize a variável no início
    void Awake()
    {
        
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void SetVolume(float volume)
    {
        // Encontra a instância única do MusicManager e pede para ela ajustar o volume.
        if (MusicManager.instance != null)
        {
            MusicManager.instance.SetMasterVolume(volume);
        }
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

}
