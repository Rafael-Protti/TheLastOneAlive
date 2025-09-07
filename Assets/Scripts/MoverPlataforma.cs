using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class MoverPlataforma : MonoBehaviour
{
    public float velocidade = 5;
    public float distancia = 5;
    public bool vertical = false;
    public bool armadilha = false;
    int direcao = 1;
    Vector3 proximaPosicao;
    Vector3 posicaoInicial;
    void Start()
    {
        posicaoInicial = transform.position;
    }
    void Update()
    {
        proximaPosicao.x = posicaoInicial.x + distancia;
        proximaPosicao.y = posicaoInicial.y + distancia;

        if (!vertical)
        {
            if (transform.position.x < proximaPosicao.x && direcao == 1)
            {
                Vector3 movimento = new Vector3(direcao, 0);
                transform.position += movimento * velocidade * Time.deltaTime;
            }

            if (transform.position.x >= proximaPosicao.x)
            {
                direcao *= -1;
            }

            if (direcao == -1 && transform.position.x > posicaoInicial.x)
            {
                Vector3 movimento = new Vector3(direcao, 0);
                transform.position += movimento * velocidade * Time.deltaTime;
            }

            if (transform.position.x <= posicaoInicial.x)
            {
                direcao *= -1;
            }
        }

        else
        {
            if (transform.position.y < proximaPosicao.y && direcao == 1)
            {
                Vector3 movimento = new Vector3(0, direcao);
                transform.position += movimento * velocidade * Time.deltaTime;
            }

            if (transform.position.y >= proximaPosicao.y)
            {
                direcao *= -1;
            }

            if (direcao == -1 && transform.position.y > posicaoInicial.y)
            {
                Vector3 movimento = new Vector3(0, direcao);
                transform.position += movimento * velocidade * Time.deltaTime;
            }

            if (transform.position.y <= posicaoInicial.y)
            {
                direcao *= -1;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !armadilha)
        {
            collision.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !armadilha)
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
