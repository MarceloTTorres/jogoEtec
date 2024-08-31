using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energia_Bar : MonoBehaviour
{
    private Item item;
    public Slider slider;
    // public Gradient gradiente;
    public Image imagem;
    public int maxEnergia = 120;
    
    public int energiaAtual;

    private void Start()
    {
        energiaAtual = maxEnergia;
    }
    public void SetMaxEnergia(float energia)
    {
        slider.maxValue = energia;
        slider.value = energia;

        // imagem.color = gradiente.Evaluate(1f);
    }

    public void SetEnergia(float energia)
    {
        slider.value = energia;
        // imagem.color = gradiente.Evaluate(slider.normalizedValue);
    }

    public void GanhoEnergia(Item item)
    {
        SetEnergia(slider.value + item.item_energia);
    }
}
