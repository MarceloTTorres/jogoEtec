
using UnityEditor.Experimental.GraphView; //  inclui o namespace para a GraphView experimental do Unity
using UnityEngine; //  inclui o namespace necessário para usar as funcionalidades do Unity; permite o uso das funcionalidades do Unity, como componentes e funções relacionadas à renderização, física e controle de entrada
using UnityEngine.SceneManagement; // inclui o namespace para gerenciamento de cenas no Unity


// define uma nova classe chamada Invaders que herda de MonoBehaviour, tornando-a um componente que pode ser anexado a objetos na Unity.
public class Invaders : MonoBehaviour
{
    // [Header("Invader")] cria uma seção no Inspector do Unity para as variáveis relacionadas aos invaders
    [Header("Invaders")]
    public Invader[] prefabs = new Invader[5]; // é um array público de prefabs de invaders que pode ser configurado no Inspector do Unity
    public AnimationCurve speed = new AnimationCurve(); // define uma curva de animação para a velocidade dos invaders (gráfico de velocidade) 
    private Vector3 direction = Vector3.right; // define a direção inicial do movimento dos invaders
    private Vector3 initialPosition; // armazena a posição inicial dos invaders

    // // [Header("Grid")] cria uma seção no Inspector do Unity para as variáveis relacionadas a grade dos invasores
    [Header("Grid")] 
    public int rows = 5; // número de linhas de invasores, pode ser alterado no inspector
    public int columns = 11; // numero de invasores em cada uma das 5 linhas 

    // cria uma seção no Inspector do Unity para as variáveis relacionadas aos mísseis
    [Header("Missiles")]
    public Projectile missilePrefab; //  define o prefab do míssil que os invaders vão disparar
    public float missileSpawnRate = 1.0f; // define a taxa de disparo dos mísseis.

    // private void Awake é um método do ciclo de vida da Unity que é chamado quando o script é iniciado
    private void Awake() //inicio
    {
        initialPosition = transform.position; // armazena a posição inicial do transform

        CreateInvaderGrid(); // chama o método CreateInvaderGrid para criar a grade de invaders qdo o jogo inicia

    }

    // private void CreateInvaderGrid cria a grade de invaders
    private void CreateInvaderGrid()
    {
        for (int i = 0; i < rows; i++) // percorre cada linha
        {

            float width = 2.0f * (columns - 1);
            float height = 2.0f * (rows - 1); // linha 41 e 42: calculam a largura e a altura da grade.

            Vector2 centerOffset = new Vector2(-width * 0.5f, -height * 0.5f); // calcula o deslocamento central para centralizar a grade
            Vector3 rowPosition = new Vector3(centerOffset.x, (2f * i) + centerOffset.y, 0f); // calcula a posição da linha

            for (int j = 0; j < columns; j++) // percorre cada coluna
            {
                Invader invader = Instantiate(prefabs[i], transform); // instancia um invader na hierarquia do transform atual

                Vector3 position = rowPosition;
                position.x += 2f * j;
                invader.transform.localPosition = position; // linha 51, 52 e 53:  calcula e define a posição do invader
            }
        }
    }

    // o private void start tambem é um método do ciclo de vida do Unity, mas diferente do awake, Start que é chamado antes do primeiro frame update
    private void Start()
    {
        InvokeRepeating(nameof(MissileAttack), missileSpawnRate, missileSpawnRate); // chama o método "MissileAttack" repetidamente após um tempo inicial "missileSpawnRate" e continua chamando-o a cada "missileSpawnRate" segundos
    }

    // esta função gerencia os ataques de mísseis dos invaders
    private void MissileAttack()
    {
        int amountAlive = GetAliveCount(); //  obtém a contagem de invaders sobreviventes player peligrosso

        if (amountAlive == 0) // retorna se não houver invaders vivos
        {
            return;
        }

        foreach (Transform invader in transform) // percorre cada invader na hierarquia do transform atual
        {
            if (!invader.gameObject.activeInHierarchy) // linha 76~78: ignora invaders que não estão ativos
            {
                continue;
            }

            if (Random.value < (1f / amountAlive)) // determina aleatoriamente se um invader deve disparar um míssil
            {
                Instantiate(missilePrefab, invader.position, Quaternion.identity); // instancia um míssil na posição do invader
                break;
            }
        }
    }

    // o void update é chamado a cada frame e gerencia o movimento dos invaders
    // // private void update é um método do ciclo de vida do Unity que é chamado uma vez por frame e é usado para atualizar a lógica do jogo
    private void Update()
    {
        int totalCount = rows * columns; // vê o total de invaders
        int amountAlive = GetAliveCount(); // obtém a contagem de invaders vivos
        int amountKilled = totalCount - amountAlive; // calcula a contagem de invaders mortos
        float percentKilled = amountKilled / (float)totalCount; // calcula a porcentagem de invaders mortos

        float speed = this.speed.Evaluate(percentKilled); // avalia a velocidade dos invaders com base na porcentagem de invaders mortos
        transform.position += speed * Time.deltaTime * direction; // move os invaders na direção atual

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero); 
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right); // linha 100 e 101: calcula as bordas esquerda e direita da tela

        foreach (Transform invader in transform) // percorre cada invader na hierarquia do transform atual
        {
            if (!invader.gameObject.activeInHierarchy) 
            {
                continue;
            } //  linha 105~108: ignora invaders que não estão ativos

            if (direction == Vector3.right && invader.position.x >= (rightEdge.x - 1f))
            {
                AdvanceRow();
                break;
            } // linha 110~114:  avança a linha se o invader na borda direita atingir o limite
            else if (direction == Vector3.left && invader.position.x <= (leftEdge.x + 1f))
            {
                AdvanceRow();
                break;
            } // linha 115~119: avança a linha se o invader na borda esquerda atingir o limite
        }
    }

    // a função AdvanceRow muda a direção do movimento dos invaders e avança a linha para baixo, qdo bate na borda e inverte o lado
    private void AdvanceRow()
    {
        direction = new Vector3(-direction.x, 0f, 0f); // inverte a direção horizontal do movimento

        Vector3 position = transform.position;
        position.y -= 1f;
        transform.position = position; // linha 128~130: move a linha de invaders uma unidade para baixo
    }

    // função que redefine a posição e o estado dos invaders
    public void ResetInvaders()
    {
        direction = Vector3.right; //  redefine a direção do movimento
        transform.position = initialPosition; // redefine a posição dos invaders para a posição inicial

        foreach (Transform invader in transform)
        {
            invader.gameObject.SetActive(true);
        } // linha 139~142: reativa todos os invaders na hierarquia
    }

    // public int GetAliveCount retorna a contagem de invaders vivos
    public int GetAliveCount()
    {
        int count = 0; //  inicializa a contagem

        foreach (Transform invader in transform)
        {
            if (invader.gameObject.activeSelf)
            {
                count++;
            }
        } // linha 150~156: percorre cada invader e incrementa a contagem se o invader estiver ativo

        return count; // retorna a contagem de invaders vivos
    }

}

// Anotações do Script:
// MonoBehaviour é a classe base da qual deriva todo script da Unity

// Um array (arranjo ou vetor) é um conjunto de dados (que pode assumir os mais diversos tipos,
// desde do tipo primitivo, a objeto dependendo da linguagem de programação).
// Arrays são utilizados para armazenar mais de um valor em uma única variável.
// Isso é comparável a uma variável que pode armazenar apenas um valor.

// linha 1 e 3, não estão sendo usadas diretamente

// namespace: conjuntos de identificadores que tem como função agrupar funcionalidades comuns assim também organizando-as. é um conceito da programação que permite organizar e agrupar elementos relacionados, como classes, funções e variáveis, em um contexto específico
