using System.Collections; // nome do script: NPCTorres (provisório)
using UnityEngine;
using UnityEngine.UI;

public class NPCTorres : MonoBehaviour
{
    public GameObject painelDialogo;
    public Text textoDialogo;
    public string[] dialogo;
    private int index;

    public GameObject botaoContinuar;

    public float velocidadeTexto;
    public bool playerIsClose;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && playerIsClose)
        {
            if (painelDialogo.activeInHierarchy)
            {
                zeroTexto();
            }
            else
            {
                painelDialogo.SetActive(true);
                StartCoroutine(Digitando());
            }
        }

        if (textoDialogo.text == dialogo[index])
        {
            botaoContinuar.SetActive(true);
        }
    }

    public void zeroTexto()
    {
        textoDialogo.text = "";
        index = 0;
        painelDialogo.SetActive(false);
    }

    IEnumerator Digitando()
    {
        foreach (char letter in dialogo[index].ToCharArray())
        {
            textoDialogo.text += letter;
            yield return new WaitForSeconds(velocidadeTexto);
        }
    }

    public void ProximaLinha()
    {
        botaoContinuar.SetActive(false);
        if (index < dialogo.Length - 1)
        {
            index++;
            textoDialogo.text = "";
            StartCoroutine(Digitando());
        }
        else
        {
            zeroTexto();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            // zeroTexto();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroTexto();
        }
    }
}
