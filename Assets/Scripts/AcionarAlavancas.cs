using TMPro;
using UnityEngine;

public class AcionarAlavancas : MonoBehaviour
{
    public TextMeshProUGUI texto;
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !acionada)
        {
            acionando.SetBool("acionada", true);
            acionada = true;
            Destroy(portao);
            texto.text = "<color=green>Um portão foi aberto!</color>";
            Invoke("LimparMensagem", 3);

        }
    }

    void LimparMensagem()
    {
        texto.text = "";
    }
}
