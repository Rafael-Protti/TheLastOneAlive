using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Player : MonoBehaviour
{
    Rigidbody2D rigib;
    Animator anima;

    public static int pontos = 50;
    public int vida = 50;
    public float velo = 10;
    public float velomax = 5;
    public float forcaPulo = 10;
    public float forcaDash = 100;
    public bool estaDireita = true;

    int pontosmax;
    int vidamax;
    bool podePular = true;
    Vector2 posicao_inicial;
    Vector2 checkpoint;

    TextMeshProUGUI texto_vida;
    TextMeshProUGUI texto_pontos;
    TextMeshProUGUI pontuacao;
    void Start()
    {
        texto_vida = GameObject.Find("VidaTexto").transform.GetComponent<TextMeshProUGUI>();
        texto_pontos = GameObject.Find("PontosTexto").transform.GetComponent<TextMeshProUGUI>();
        pontuacao = GameObject.Find("Evento").transform.GetComponent<TextMeshProUGUI>();
        rigib = transform.GetComponent<Rigidbody2D>();
        anima = transform.GetComponent<Animator>();
        posicao_inicial = transform.position;
        vidamax = vida;
        pontosmax = pontos;
    }

    // Update is called once per frame
    void Update()
    {
        Interface();
        bool ataque = Input.GetKey(KeyCode.RightShift);

        if (ataque && podePular == true || podePular == false)
        {
            anima.SetBool("estaAtacando", true);
        }
        else
        {
            anima.SetBool("estaAtacando", false);
        }

        

        GameOver();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        //movimento do player
        float move = Input.GetAxisRaw("Horizontal");

        //virar sprite
        if (move == 1)
        {
            transform.eulerAngles = new Vector2(0, 0);
            estaDireita = true;
        }
        if (move == -1)
        {
            transform.eulerAngles = new Vector2(0, 180);
            estaDireita = false;
        }

        rigib.AddForce(new Vector2(move * velo, 0));

        move = move * velo * Time.deltaTime;
        rigib.linearVelocityX = Mathf.Clamp(rigib.linearVelocityX, -velomax, velomax);

        //animação de corrida
        if (rigib.linearVelocityX < 0.1f && rigib.linearVelocityX > -0.1f)
        {
            anima.SetBool("estaCorrendo", false);
        }
        else
        {
            anima.SetBool("estaCorrendo", true);
        }

        //pulo do player
        bool pulo = Input.GetAxisRaw("Jump") > 0;
        if (pulo == true && podePular == true)
        {
            anima.SetBool("estaPulando", true);
            rigib.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
        }

        rigib.linearVelocityY = Mathf.Clamp(rigib.linearVelocityY, -forcaPulo, forcaPulo);
    }


    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) //a layer 6 é o "Ground". Por algum motivo, só funciona com o número.
        {
            podePular = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) //a layer 6 é o "Ground". Por algum motivo, só funciona com o número.
        {
            podePular = true;
            anima.SetBool("estaPulando", false);
        }

        if (collision.gameObject.CompareTag("Princesa"))
        {
            pontuacao.text = "<color=blue>Sua pontuação final foi: " + pontos;
            Invoke("CarregarCena", 4);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7 || collision.gameObject.CompareTag("Inimigo")) //trap = 7
        {
            PerderVida();
        }

        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            checkpoint = collision.gameObject.transform.position;
        }
    }

    void PerderVida()
    {
        vida -= 1;
    }

    void Interface()
    {
        texto_vida.text = "<color=red>Vida: " + vida + "</color>";
        texto_pontos.text = "<color=blue>Pontos: " + pontos + "</color>";
    }

    void GameOver()
    {
        if (vida <= 0)
        {
            pontos -= 10;
            transform.position = checkpoint;
            vida = vidamax;
        }

        if (pontos < -50)
        {
            SceneManager.LoadScene("CenaSecreta");
        }
    }

    void CarregarCena()
    {
        SceneManager.LoadScene("FimDeJogo");
    }

}
