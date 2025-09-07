using UnityEngine;

public class AcionarAlavancas : MonoBehaviour
{
    public GameObject portao;
    Animator acionando;
    bool acionada = false;
    void Start()
    {
        acionando = transform.GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !acionada)
        {
            acionando.SetBool("acionada", true);
            acionada = true;
            Destroy(portao);
        }
    }
}
