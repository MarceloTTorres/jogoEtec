
using UnityEngine; //  inclui o namespace necessário para usar as funcionalidades do Unity; permite o uso das funcionalidades do Unity, como componentes e funções relacionadas à renderização, física e controle de entrada

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))] // linha 4, 5 e 6: garantem que os componentes SpriteRenderer, Rigidbody2D e BoxCollider2D estejam presentes no Objeto do Jogo ao qual o script está anexado. Se não estiverem, o Unity os adiciona automaticamente.

// define uma nova classe chamada Invader que herda de MonoBehaviour, tornando-a um componente que pode ser anexado a objetos na Unity.
public class Invader : MonoBehaviour
{
    public Sprite[] animationSprites = new Sprite[0]; // é um array público de sprites que será usado para a animação do invader. Pode ser configurado no Inspector da Unity
    public float animationTime = 1.0f; // define o tempo entre cada quadro da animação (invasor contraido/invasor "aberto"
    public int score = 10; // pontos que o jogador recebe ao acertar o invasor, e por ser publico, pode ser alterado tanto aqui no script como tambem no Inspector

    private SpriteRenderer spriteRenderer; // é uma referência privada ao componente SpriteRenderer
    private int animationFrame; //é um índice que rastreia o quadro atual da animação.

    // private void Awake é um método do ciclo de vida da Unity que é chamado quando o script é iniciado
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // obtém o componente SpriteRenderer anexado ao GameObject
        spriteRenderer.sprite = animationSprites[0]; // define o sprite inicial do SpriteRenderer como o primeiro sprite da animação
    }

    // assim como o private void Awake, o private void start tambem é um método do ciclo de vida do Unity, mas diferente do awake, Start que é chamado antes do primeiro frame update
    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), animationTime, animationTime); // chama o método "AnimateSprite" repetidamente após um tempo inicial "animationTime" e continua chamando-o a cada "animationTime" segundos
    }

    // é um método que altera o sprite do SpriteRenderer para criar uma animação.
    private void AnimateSprite()
    {
        animationFrame++; // incrementa o índice do quadro da animação.

        
        if (animationFrame >= animationSprites.Length) // reinicia o índice da animação se ele ultrapassar o número de sprites disponíveis.
        { 
            animationFrame = 0;
        }

        spriteRenderer.sprite = animationSprites[animationFrame]; // define o sprite atual do SpriteRenderer como o sprite correspondente ao quadro da animação.

    }

    // private void OntriggerEnter2D é chamado quando outro colisor entra no BoxCollider2D do invader.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Laser")) // verifica se o objeto que colidiu pertence à camada "Laser"
        {
            GameManager.Instance.OnInvaderKilled(this); // chama o método OnInvaderKilled do GameManager para tratar a destruição do invader e provavelmente incrementar a pontuação do jogador
        } else if (other.gameObject.layer == LayerMask.NameToLayer("Boundary")) // verifica se o objeto que colidiu pertence à camada "Boundary"
        {
            GameManager.Instance.OnBoundaryReached(); // chama o método OnBoundaryReached do GameManager para tratar a colisão do invader com os limites do jogo, o que pode desencadear uma reação específica, como mover os invaders para baixo.
        }

        }
    }

// Anotações do Script:
// MonoBehaviour é a classe base da qual deriva todo script da Unity
// Um array (arranjo ou vetor) é um conjunto de dados (que pode assumir os mais diversos tipos,
// desde do tipo primitivo, a objeto dependendo da linguagem de programação).
// Arrays são utilizados para armazenar mais de um valor em uma única variável.
// Isso é comparável a uma variável que pode armazenar apenas um valor.
// referencia à linha 16: Um índice é um indicador, um fator de referência, que serve
// de comparador para explicar determinada situação ou condição.
// namespace: conjuntos de identificadores que tem como função agrupar funcionalidades comuns assim também organizando-as. é um conceito da programação que permite organizar e agrupar elementos relacionados, como classes, funções e variáveis, em um contexto específico
