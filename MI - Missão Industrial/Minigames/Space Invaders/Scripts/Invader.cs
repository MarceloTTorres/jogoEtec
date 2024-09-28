
using System;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine; // Permite o uso de funcionalidades da Unity, como componentes visuais, físicas, entrada de usuário enfim

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))] // linha 4, 5 e 6: garantem que os componentes citados estejam no objeto do jogo (nesse caso, os aliens), e se não estivessemr efenrenciados aqui a Unity os adicionaria automaticamente. São bibliotecas

public class Invader : MonoBehaviour
{
    public Sprite[] animationSprites = new Sprite[0]; // um array/conjunto de imagens para fazer a animaçãozinha dele abrindo e fechando as mãos - ilusão de movimento
    public float animationTime = 1.0f; // tempo de troca entre uma imagem e outra da variável acima
    public int score = 10; // valor do invasor depois de aniquilados kkk
    private SpriteRenderer spriteRenderer; // lá no inspector, é onde as sprites do invasor vão ser add
    private int animationFrame; // mantém o controle de qual sprite está sendo exibido no momento, dentro do array de animationSprites

    private void Awake() // "desperta" assim que o objeto for instanciado. esse método está pegando o componente do spriteRenderer e definindo a sprite inicial
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = animationSprites[0];
    }

    private void Start() //  É chamado logo após Awake, por aqui o método InvokeRepeating é usado para chamar o método AnimateSprite varias vezez com um intervalo definido pelo animationTime.
    {
        InvokeRepeating(nameof(AnimateSprite), animationTime, animationTime);
    }

    private void AnimateSprite()
    {
        animationFrame++;

        if (animationFrame >= animationSprites.Length){
            animationFrame = 0;
        }

        spriteRenderer.sprite = animationSprites[animationFrame];

    } // esse método é um increment. ele incrementa o animationframe a cada chamada, se o valor for > ou = ao numero de sprites no conjunto de invasores ele se redefine pra 0, fazendo com que a animação reinicia, depois ele atualiza o sprite visível do alien com o sprite correspondente    

    private void OnTriggerEnter2D(Collider2D other) // método chamado quando o invasor colidir com outro objeto do jogo
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Laser")) // Se o objeto que colidiu com um Lasers isso é lido como: que o alien foi atingido por um laser, e o método OnInvaderKilled do GameManager é chamado, passando o alienígena como argumento.
        {
            GameManager.Instance.OnInvaderKilled(this);
        } else if (other.gameObject.layer == LayerMask.NameToLayer("Boundary"))
        {
            GameManager.Instance.OnBoundaryReached(); // se o objeto colidiu com o boundary, o método OnBoundaryReached é chamado no GameManager
        }

        }
    }

// Anotações do Script:

// Canal ZIGOROUS 

// void = método

// MonoBehaviour é a classe base da qual deriva todo script da Unity

// namespace: conjuntos de identificadores que tem como função agrupar funcionalidades comuns assim também organizando-as. é um conceito da programação que permite organizar e agrupar elementos relacionados, como classes, funções e variáveis, em um contexto específico

// A renderização gráfica é o processo de gerar uma imagem a partir de um modelo 2D ou 3D utilizando um software especializado, como motores gráficos em jogos, editores de imagem ou simuladores visuais. Esse processo transforma dados (geometria, texturas, luzes, sombras) em imagens visíveis na tela.

// array: é uma estrutura de dados que armazena uma coleção de elementos do mesmo tipo. Em um array, os elementos são organizados de maneira sequencial e cada um deles pode ser acessado por um índice (ou posição)

//void não retorna valor 

// Método Apply: esse método nn precisaa ser criado por que já pertence a classse "Texture2D" para aplicar as alterações feitas na nova textura. Sem o Apply nn teriam mudanças exibidas, ja que as mudanças nn são automaticas

// bool: 0 ou 1; Verdadeiro ou falso, true or fake

// linha 66: método CheckPoint é chamado para verificar se o ponto de impacto é válido dentro da textura. Ele também calcula as coordenadas da textura (px e py) com base no ponto de impacto. Se o ponto de impacto for inválido, a função retorna false (linha 77), o que indica que não foi possível aplicar o splat

// void Awake: // é um método do ciclo de vida da Unity que é chamado quando o script é iniciado

// argumento: valor ou referência que você passa para uma função, método ou procedimento quando ela é chamada. Esses valores servem como entrada para que a função possa realizar suas operações
