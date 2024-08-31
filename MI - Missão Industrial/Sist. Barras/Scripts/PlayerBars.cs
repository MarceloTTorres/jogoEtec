using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBars : MonoBehaviour
{
    public int maxConhecimento = 120;
    public int conhecimentoAtual;

    private Conhecimento _conhecimento;

    private void Start()
    {
        conhecimentoAtual = maxConhecimento;
        _conhecimento.SetMaxHealth(conhecimentoAtual); 

    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage (int dano)
    {
        conhecimentoAtual += dano;
    }
}

// public class conhecimento
//{
 //internal void SetMaxConhecimento(int maxConhecimento)
  // {
   //    throw new NotImplementedException();
  //}
//}

