using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodigoVolumen : MonoBehaviour
{
    public Slider slider;
    public Slider brillo;
    public float slidervalue;
    public Image imagenMute;
    public Image imagenBrillo;
    void Start()
    {   
        slider.value = PlayerPrefs.GetFloat("VolumenAudio", 0.5f);//obtener la posicion donde este el slider
        brillo.value = PlayerPrefs.GetFloat("Brillo", 0);//obtener la posicion donde este el slider
        AudioListener.volume = slider.value;
        RevisarSiEstoyMute();
    }
    public void ChangeSlider (float valor)
    {
        slidervalue = valor;
        PlayerPrefs.SetFloat("VolumenAudio", slider.value);
        AudioListener.volume = valor;
        RevisarSiEstoyMute();
    }
    public void CambiarBrillo(float valor)
    {
        
        PlayerPrefs.SetFloat("Brillo", valor);
        imagenBrillo.color = new Color(0, 0, 0, valor);
    }
    public void RevisarSiEstoyMute()
    {
        if (slidervalue==0)
        {
            imagenMute.enabled = true;
        }
        else
        {
            imagenMute.enabled = false;
        }
    }
    void Update()
    {
        
    }
}
