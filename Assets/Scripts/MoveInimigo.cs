using UnityEngine;

public class MoveInimigo : MonoBehaviour
{
    // Detecta o jogador em outro script
    public bool player_visto = false;
    // A cada quantos segundos o inimigo deve virar.
    public float tempoParaVirar = 2f;

    //Velocidade que o camarada anda
    public float velocidade = 2;
    public float velocidade_multi = 2;
    public float velocidade_inicial = 2;

    float velocidade_rapida;

    //A dist�ncia que o nobre caminha
    public float distancia = 2;

    //Onde o morto est�?
    Vector2 posicao_inicial;
    Vector2 posicao_final;

    // Vari�vel para o temporizador.
    float temporizador;

    // A dire��o atual do sprite (1 = direita, -1 = esquerda).
    int direcao = 1;

    void Start()
    {
        // Define o valor inicial do temporizador.
        temporizador = tempoParaVirar;

        //Posi��o que o inimigo come�a
        posicao_inicial = transform.position;

        //Manipula��o de velocidade
        velocidade_rapida = velocidade * velocidade_multi;
        velocidade_inicial = velocidade;
    }

    void Update()
    {
        PlayerVisto();
        MoverInimigo();
        
    }

    void PlayerVisto()
    {
        if (player_visto) { velocidade = velocidade_rapida; }
        else { velocidade = velocidade_inicial; }
    }
    void MoverInimigo()
    {
        // Onde o pangu�o vai?
        posicao_final.x = posicao_inicial.x + distancia;

        // Diminui o temporizador a cada frame.
        //temporizador -= Time.deltaTime; //desativado pela troca da condi��o.

        // Se o temporizador chegou a zero ou menos, � hora de virar.
        /* if (temporizador <= 0) Desativado pela troca de condi��o
         {
             // Inverte a dire��o: 1 vira -1, e -1 vira 1.
             direcao *= -1;

             // Inverte a escala X do sprite para virar a imagem.
             transform.localScale = new Vector2(direcao, 1);

             // Reseta o temporizador para a pr�xima virada.
             temporizador = tempoParaVirar;
         }*/

        if (transform.position.x >= posicao_final.x)
        {
            direcao = -1;
        }
        if (transform.position.x <= posicao_inicial.x)
        {
            direcao = 1;
        }
        // Move o esqueleto
        Vector3 movimento = new Vector3(direcao, 0);
        transform.position += movimento * velocidade * Time.deltaTime;
        //Inverte o sprite
        transform.localScale = new Vector2(direcao, 1);
    }
}
