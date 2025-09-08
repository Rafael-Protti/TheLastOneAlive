using TMPro;
using UnityEngine;

public class AbrirBaus : MonoBehaviour
{
    public GameObject grade;
    public int chavesnecessarias = 0;
    public static int baus = 0;
    TextMeshProUGUI aviso;
    TextMeshProUGUI texto;
    Animator abrefecha;
    void Start()
    {
        texto = GameObject.Find("BausTexto").transform.GetComponent<TextMeshProUGUI>();
        aviso = GameObject.Find("Evento").transform.GetComponent<TextMeshProUGUI>();
        abrefecha = transform.GetComponent<Animator>();
    }


    void Update()
    {
        texto.text = "<color=purple>Baús: " + baus + "/3</color>";
        if (baus >= 3)
        {
            Invoke("AvisoFinal", 5);
            Invoke("LimparAviso", 10);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !abrefecha.GetBool("aberto") && ColetarChaves.coletada >= chavesnecessarias)
        {
            abrefecha.SetBool("aberto", true);
            baus++;
            Destroy(grade);
            aviso.text = "<color=purple>Uma barreira foi quebrada!</color>";
            Invoke("LimparAviso", 3);
        }
    }

    void AvisoFinal()
    {
        aviso.text = "<color=green>Retorne para o início da fase.</color>";
        
    }

    void LimparAviso()
    {
        aviso.text = "";
    }

    
}
