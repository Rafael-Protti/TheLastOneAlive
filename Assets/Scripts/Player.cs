using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigib;

    public float velo = 10;
    public float velomax = 5;

    void Start()
    {
        rigib = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        bool pulo = Input.GetAxisRaw("Jump") > 0;
    }

    void FixedUpdate()
    {
        float move = Input.GetAxisRaw("Horizontal");

        rigib.AddForce(new Vector2(move * velo, 0));

        move = move * velo * Time.deltaTime;
        rigib.linearVelocityX = Mathf.Clamp(rigib.linearVelocityX, -velomax, velomax);
    }

}
