using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigib;

    public float velo = 10;
    public float velomax = 5;
    public float forcaPulo = 10;
    bool podePular = true; 

    void Start()
    {
        rigib = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //movimento do player
        float move = Input.GetAxisRaw("Horizontal");

        rigib.AddForce(new Vector2(move * velo, 0));

        move = move * velo * Time.deltaTime;
        rigib.linearVelocityX = Mathf.Clamp(rigib.linearVelocityX, -velomax, velomax);

        //pulo do player
        bool pulo = Input.GetAxisRaw("Jump") > 0;
        if (pulo == true && podePular == true)
        {
            rigib.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
            podePular = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            podePular = true;
        }    
    }

}
