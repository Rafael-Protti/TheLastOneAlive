using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float move = Input.GetAxisRaw("Horizontal");

        if (move == 1)
        {
            transform.eulerAngles = new Vector2(0, 0);
            estaOlhandoDireita = true;
        }
        if (move == -1)
        {
            transform.eulerAngles = new Vector2(0, 180);
            estaOlhandoDireita = false;
        }

        rigib.AddForce(new Vector2(move * velo, 0));

        move = move * velo * Time.deltaTime;
        rigib.linearVelocityX = Mathf.Clamp(rigib.linearVelocityX, -velomax, velomax);
    }
}
