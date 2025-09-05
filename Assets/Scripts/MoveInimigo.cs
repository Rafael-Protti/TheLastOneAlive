using UnityEngine;

public class MoveInimigo : MonoBehaviour
{
    // A cada quantos segundos o inimigo deve virar.
    public float tempoParaVirar = 2f;

    // Variável para o temporizador.
    private float temporizador;

    // A direção atual do sprite (1 = direita, -1 = esquerda).
    private int direcao = 1;

    void Start()
    {
        // Define o valor inicial do temporizador.
        temporizador = tempoParaVirar;
    }

    void Update()
    {
        // Diminui o temporizador a cada frame.
        temporizador -= Time.deltaTime;

        // Se o temporizador chegou a zero ou menos, é hora de virar.
        if (temporizador <= 0)
        {
            // Inverte a direção: 1 vira -1, e -1 vira 1.
            direcao *= -1;

            // Inverte a escala X do sprite para virar a imagem.
            transform.localScale = new Vector2(direcao, 1);

            // Reseta o temporizador para a próxima virada.
            temporizador = tempoParaVirar;
        }
    }
}
