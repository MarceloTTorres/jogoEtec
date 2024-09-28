
using UnityEngine; // Permite o uso de funcionalidades da Unity, como componentes visuais, físicas, entrada de usuário enfim
using UnityEngine.Rendering; // Usado pras funções de renderizar (gerar imagem a partir de um modelo

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))] // linhas 5 e 6: garantem que os componentes SpriteRenderer e BoxCollider2D estejam presentes no objeto do jogo (Bunker) ao qual o script está anexado. Se não estiverem, a Unity os adiciona automaticamente. EM TODODS OS SCRIPTS

public class Bunker : MonoBehaviour
{
    public Texture2D splat; // textura do dano
    private Texture2D originalTexture; // aqui fica a textura original do SpriteRenderer, o Bunker intacto e o originalTexture armazena pra restaurar depois   
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider; // Linha 12 e 13: referências aos componentes SpriteRenderer e BoxCollider2D anexados ao GameObject (bunker)

    private void Awake() // ele tem as referências para os componentes anexados ao bunker e armazena a textura original do sprite para futuros resets
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  // aqui fica o componente SpriteRenderer anexado ao GameObject
        boxCollider = GetComponent<BoxCollider2D>();  // obtém o componente BoxCollider2D anexado ao GameObject
        originalTexture = spriteRenderer.sprite.texture; // aqui fica a textura original do objeto retratato, o Bunker

        ResetBunker(); // aqui esta chamando um método que reincia o Bunker
    }

    public void ResetBunker()  // reseta o bunker para o jeito que ele era inicialmente e o ativa de novo - reiniciar o estado do bunker após uma rodada
    {
        CopyTexture(originalTexture); // aqui cria uma cópia da textura original (bunker inteirinho)

        gameObject.SetActive(true);  // e aqui ativa o GameObject/Bunker
    }

    
    private void CopyTexture(Texture2D source)  // cria uma cópia da textura - preserva a textura e aplica essa cópia no SpriteRenderer                            // Texture2D source é a textura que foi copiada
    {
        Texture2D copy = new Texture2D(source.width, source.height, source.format, false) // cria uma nova textura com as mesmas propriedades da textura original
        // source.width e source.height é o tamanho do objeto, e qdo um novo for criado terá o tamanho ja "registrado" neles
        // source = textura original
        {
            filterMode = source.filterMode, // A propriedade filterMode da nova textura é definida para ser igual à da textura original 
            anisoLevel = source.anisoLevel, // A propriedade anisoLevel da nova textura é copiada da textura original. Melhora a qualidade da textura quando 
            wrapMode = source.wrapMode // controla o comportamento da textura quando o objeto que ela está cobrindo ultrapassa os limites da textura

        };

        copy.SetPixels32(source.GetPixels32()); //copia os pixels da textura original (StPx) para a nova textura, o GetPx recupera os pixel da textura original
                                                
        copy.Apply(); // aqui chama o método Apply  

        Sprite sprite = Sprite.Create(copy, spriteRenderer.sprite.rect, new Vector2(0.5f, 0.5f), spriteRenderer.sprite.pixelsPerUnit);// cria um novo sprite a partir da nova textura, ou seja, um bunker novo todo detonado
        spriteRenderer.sprite = sprite;  // define o novo sprite no SpriteRenderer como o "original" até a proxima detonação
    }

    public bool CheckCollision(BoxCollider2D other, Vector3 hitPoint) // verifica se houve colisão com o bunker 
    {
        Vector2 offset = other.size / 2; // calcula o deslocamento do colisor

        return Splat(hitPoint) || // aqui esta verificando se o ponto de colisão ou os pontos ao redor causam um splat/textura depois da colisão 
               Splat(hitPoint + (Vector3.down * offset.y)) ||
               Splat(hitPoint + (Vector3.up * offset.y)) ||
               Splat(hitPoint + (Vector3.left * offset.x)) ||
               Splat(hitPoint + (Vector3.right * offset.x)); // hitpoint: ponto de impacto
    }
    
    private bool Splat(Vector3 hitPoint) // aplica um dano visual (splat) na textura no ponto onde o projetil ou o missil acertarem na texura atual com base em um ponto de impacto
    {
        if (!CheckPoint(hitPoint, out int px, out int py)) // verifica se o ponto de impacto é válido e obtém as coordenadas da textura
                                                           
        {
            return false; // Se CheckPoint retornar falso, o método Splat também retorna false e a execução é interrompida, ou seja, nenhum splat será aplicado aqui
        }

        Texture2D texture = spriteRenderer.sprite.texture; // obtém a textura atual do sprite

        px -= splat.width / 2;
        py -= splat.height / 2; // linha 83 e 84: centraliza o splat em relação ao ponto de impacto; x=largura, y=altura

        int startX = px; // armazena a posição inicial do px, que depois servirá de referência ao percorrer as linhas da textura do splat

        for (int y = 0; y < splat.height; y++) // Esse loop percorre cada linha de pixels da textura e altura (height) do splat
        {
            px = startX; // a cada nova linha (y), o valor de px é redefinido para startX, garantindo que o loop de pixels na horizontal comece na mesma posição para cada linha

            for (int x = 0; x < splat.width; x++) // percorrem cada pixel do splat.
            {
                Color pixel = texture.GetPixel(px, py); // A cada iteração, obtém - se a cor do pixel na posição atual(px, py) da textura original
                pixel.a *= splat.GetPixel(x, y).a; // A transparência (a) do pixel é multiplicada pelo valor a correspondente do splat. Isso combina a transparência do splat com a transparência do pixel da textura original, criando o efeito de dano
                texture.SetPixel(px, py, pixel); // define a nova cor (com a transparência ajustada) para o pixel atual da textura
                px++;
            }

            py++; // Incrementa px para mover para o próximo pixel na mesma linha
        }

        texture.Apply(); // aplica as mudanças na textura.

        return true;
    }

    private bool CheckPoint(Vector3 hitPoint, out int px, out int py)  // converte o ponto de impacto para coordenadas da textura.
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
            gameObject.SetActive(false); // desativa o bunker se a colisão for com um invasor. PERDEU
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
