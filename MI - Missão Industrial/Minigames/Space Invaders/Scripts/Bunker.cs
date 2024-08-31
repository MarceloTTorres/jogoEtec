
using UnityEngine; // permite o uso das funcionalidades do Unity, como componentes e funções relacionadas à renderização, física e controle de entrada
using UnityEngine.Rendering; // using UnityEngine e using UnityEngine.Rendering são instruções que incluem os namespaces necessários para o código/funcionalidades                                  dentro da unity

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))] // linhas 5 e 6: garantem que os componentes SpriteRenderer e BoxCollider2D estejam presentes no objeto do jogo (Bunker) ao qual o script está anexado. Se não estiverem, a Unity os adiciona automaticamente. EM TODODS OS SCRIPTS

//public class Bunker define uma nova classe chamada Bunker que herda de MonoBehaviour, tornando-a um componente que pode ser anexado a objetos na Unity.
public class Bunker : MonoBehaviour  
{
    public Texture2D splat; // textura pública que pode ser configurada no Inspector (onde ficam as coisas do objeto ou script, do lado direito da tela, tem um "i" como ícone) da Unity. Esta textura será usada para aplicar danos visuais ao bunker qdo o missil e projetil o atingem

    private Texture2D originalTexture; // aqui fica a textura original do SpriteRenderer
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider; // Linha 14 e 15: referências privadas aos componentes SpriteRenderer e BoxCollider2D anexados ao GameObject(bunker)

    // private void Awake é um método do ciclo de vida da Unity que é chamado quando o script é iniciado
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  // aqui fica o componente SpriteRenderer anexado ao GameObject
        boxCollider = GetComponent<BoxCollider2D>();  // obtém o componente BoxCollider2D anexado ao GameObject
        originalTexture = spriteRenderer.sprite.texture; // aqui fica a textura original do objeto retratato, o Bunker

        ResetBunker(); // aqui esta chamando um método que incia o Bunker
    }

    //  o public void ResetBunker é um método público que reseta o bunker do jeito que ele era inicialmente
    public void ResetBunker()
    {
        CopyTexture(originalTexture); // aqui cria uma cópia da textura original
        gameObject.SetActive(true);  // e aqui ativa o GameObject/Bunker
    }

    // o private void CopyTexture cria uma cópia da textura fornecida
    private void CopyTexture(Texture2D source)
    {
        Texture2D copy = new Texture2D(source.width, source.height, source.format, false) // cria uma nova textura com as mesmas propriedades da textura original
        {
            filterMode = source.filterMode,
            anisoLevel = source.anisoLevel,
            wrapMode = source.wrapMode
        };

        copy.SetPixels32(source.GetPixels32()); // copia os pixels da textura original para a nova textura.
        copy.Apply(); // aqui esta aplicando as mudanças na nova textura.

        Sprite sprite = Sprite.Create(copy, spriteRenderer.sprite.rect, new Vector2(0.5f, 0.5f), spriteRenderer.sprite.pixelsPerUnit);  // cria um novo sprite a partir da nova textura, ou seja, um bunker novo todo detonado
        spriteRenderer.sprite = sprite;  // define o novo sprite no SpriteRenderer como o "original" até a proxima detonação
    }

    //  o public bool CheckCollision verifica se houve colisão com o bunker 
    public bool CheckCollision(BoxCollider2D other, Vector3 hitPoint)
    {
        Vector2 offset = other.size / 2; // calcula o deslocamento do colisor

        return Splat(hitPoint) || // aqui esta verificando se o ponto de colisão ou os pontos ao redor causam um splat/textura pontilhada depois da colisão na textura.
               Splat(hitPoint + (Vector3.down * offset.y)) ||
               Splat(hitPoint + (Vector3.up * offset.y)) ||
               Splat(hitPoint + (Vector3.left * offset.x)) ||
               Splat(hitPoint + (Vector3.right * offset.x));
    }
    // o private bool Splat aplica um splat (dano visual) na textura no ponto onde o projetil ou o missil acertaram
    private bool Splat(Vector3 hitPoint)
    {
        if (!CheckPoint(hitPoint, out int px, out int py)) // verifica se o ponto de impacto é válido e obtém as coordenadas da textura
        {
            return false;
        }

        Texture2D texture = spriteRenderer.sprite.texture; // obtém a textura atual do sprite

        px -= splat.width / 2;
        py -= splat.height / 2; // linha 73 e 74: centraliza o splat em relação ao ponto de impacto.

        int startX = px;

        for (int y = 0; y < splat.height; y++) // percorre cada pixel do splat
        {
            px = startX;

            for (int x = 0; x < splat.width; x++) // percorrem cada pixel do splat.
            {
                Color pixel = texture.GetPixel(px, py);
                pixel.a *= splat.GetPixel(x, y).a;
                texture.SetPixel(px, py, pixel); // linhas 84, 85 e 86: aplica a transparência do splat ao pixel da textura
                px++;
            }

            py++;
        }

        texture.Apply(); // aplica as mudanças na textura.

        return true;
    }

    // converte o ponto de impacto para coordenadas da textura.
    private bool CheckPoint(Vector3 hitPoint, out int px, out int py)
    {

        Vector3 localPoint = transform.InverseTransformPoint(hitPoint); // converte o ponto de impacto para coordenadas locais.

        localPoint.x += boxCollider.size.x / 2;
        localPoint.y += boxCollider.size.y / 2; // linha 104 e 105: ajusta as coordenadas locais

        Texture2D texture = spriteRenderer.sprite.texture; // obtém a textura atual do sprite

        px = (int)(localPoint.x / boxCollider.size.x * texture.width);
        py = (int)(localPoint.y / boxCollider.size.y * texture.height); // calculam as coordenadas da textura

        return texture.GetPixel(px, py).a != 0f; // verifica se o pixel na posição calculada não é totalmente transparente
    }

    // private void OnTriggerEnter2D é chamado quando outro colisor entra no BoxCollider2D do bunker
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Invader")) // verifica se o objeto que colidiu pertence à camada "Invader"
        {
            gameObject.SetActive(false); // desativa o bunker se a colisão for com um invasor. PERDEU, GAME OVER
        }
    }
}

// Anotações do Script:
// MonoBehaviour é a classe base da qual deriva todo script da Unity
// namespace: conjuntos de identificadores que tem como função agrupar funcionalidades comuns assim também organizando-as. é um conceito da programação que permite organizar e agrupar elementos relacionados, como classes, funções e variáveis, em um contexto específico
