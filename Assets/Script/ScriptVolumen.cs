using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptVolumen : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image imageMute;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        RevisarSiEstoyMute();

    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        RevisarSiEstoyMute();
    }

    public void RevisarSiEstoyMute()
    {
        if (slider.value == 0)
        {
            imageMute.enabled = true;
        }
        else
        {
            imageMute.enabled= false;
        }
    }
}
