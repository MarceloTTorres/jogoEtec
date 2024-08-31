using UnityEngine; //  permite o uso das funcionalidades do Unity, como componentes e funções relacionadas à renderização, física e controle de entrada; inclui o namespace necessário para usar as funcionalidades do Unity
using UnityEngine.SceneManagement; // permite o uso de funcionalidades para o gerenciamento de cenas

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))] // linha 4 e 5: garantem que os componentes Rigidbody2D e BoxCollider2D sejam anexados ao GameObject que possui este script. Isso é importante para garantir que o objeto tenha as propriedades físicas necessárias para interagir com o ambiente

// public class Player define uma nova classe chamada Player que herda de MonoBehaviour, tornando-a um componente que pode ser anexado a objetos no Unity
public class Player : MonoBehaviour
{
    // private Player player; 
    public Projectile laserPrefab; //  referencia o prefab do laser que o jogador irá disparar
    public float speed = 5.0f; // velocidade do jogador
    private Projectile laser; // armazena uma referência ao laser instanciado
    // private bool _laserActive;

    // private void update é um método do ciclo de vida do Unity que é chamado uma vez por frame e é usado para atualizar a lógica do jogo
    private void Update()
    {
        Vector3 position = transform.position;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            position.x -= speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            position.x += speed * Time.deltaTime;
        }

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
        position.x = Mathf.Clamp(position.x, leftEdge.x, rightEdge.x);
        transform.position = position; 

        if (laser == null && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))) 
        { 
            laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        }
    }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Missile") ||
                other.gameObject.layer == LayerMask.NameToLayer("Inavader"))
            {
                GameManager.Instance.OnPlayerKilled(this);
        }
        }
    }

// Anotações do Script:
// MonoBehaviour é a classe base da qual deriva todo script da Unity
// Um array (arranjo ou vetor) é um conjunto de dados (que pode assumir os mais diversos tipos,
// desde do tipo primitivo, a objeto dependendo da linguagem de programação).
// Arrays são utilizados para armazenar mais de um valor em uma única variável.
// Isso é comparável a uma variável que pode armazenar apenas um valor.
// namespace: conjuntos de identificadores que tem como função agrupar funcionalidades comuns assim também organizando-as. é um conceito da programação que permite organizar e agrupar elementos relacionados, como classes, funções e variáveis, em um contexto específico

