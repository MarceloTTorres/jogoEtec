using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conhecimento : MonoBehaviour
{
    public Slider slider;
    public Gradient gradiente;
    public Image progresso;  //fill


    public void SetMaxHealth(int conhecimento)
    {
        slider.maxValue = conhecimento;
        slider.value = conhecimento;
        progresso.color = gradiente.Evaluate(1f);
    }

    public void SetHealth(int conhecimento)
    {
        slider.value = conhecimento;

        progresso.color = gradiente.Evaluate(slider.normalizedValue);
    }
}

