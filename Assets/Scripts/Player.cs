using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigib;
    Animator anima;

    public float velo = 10;
    public float velomax = 5;
    public float forcaPulo = 10;
    public float forcaDash = 100;
    public bool estaDireita = true; 
    bool podePular = true;

    void Start()
    {
        rigib = transform.GetComponent<Rigidbody2D>();
        anima = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool ataque = Input.GetKey(KeyCode.RightShift);

        if (ataque && podePular == true || podePular == false)
        {
            anima.SetBool("estaAtacando", true);
        }
        else
        {
            anima.SetBool("estaAtacando", false);
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            podePular = true;
            anima.SetBool("estaPulando", false);
        }    
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
            podePular = false;
        }
    }
}
