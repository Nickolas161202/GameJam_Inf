using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing; 


public class Settings : MonoBehaviour
{
 public PostProcessVolume postProcessVolume;

    private ColorGrading colorGrading;

    // 2. Inicialize a variável no início
    void Awake()
    {
        // Tenta obter o perfil de Post-Processing e a camada ColorGrading
        if (postProcessVolume != null && postProcessVolume.profile.TryGetSettings(out colorGrading))
        {
            // A variável 'colorGrading' agora tem uma referência válida.
        }
        else
        {
            Debug.LogError("Referência de PostProcessVolume não está definida ou o perfil não contém ColorGrading.");
            // Desativa o componente para evitar erros.
            this.enabled = false; 
        }
    }


    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetBrightness(float brightnessValue) // 'brightnessValue' deve vir de um slider (0 a 1)
    {
        if (colorGrading != null)
        {
            // Mapeia o valor do slider (ex: 0-1) para uma faixa de exposição (ex: -1 a 2)
            float exposure = Mathf.Lerp(-1.5f, 2.5f, brightnessValue); // Ajustei a faixa para mais contraste
            colorGrading.postExposure.value = exposure;
        }
    }


}
