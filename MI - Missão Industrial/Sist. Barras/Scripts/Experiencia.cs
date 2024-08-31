    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class Barra_Experiencia: MonoBehaviour
    {
        public Slider slider;
        // public Gradient gradiente;
        public Image imagem;

        public void SetMaxHealth(int health)
        {
            slider.maxValue = health;
            slider.value = health;

           // imagem.color = gradiente.Evaluate(1f);
        }

        public void SetHealth(int health)
        {
            slider.value = health;

           // imagem.color = gradiente.Evaluate(slider.normalizedValue);
        }
    }
