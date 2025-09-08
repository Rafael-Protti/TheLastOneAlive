using TMPro;
using UnityEngine;

public class ColetarChaves : MonoBehaviour
{
    public static int coletada = 0;
    TextMeshProUGUI texto;
    TextMeshProUGUI aviso;

    void Start()
    {
        texto = GameObject.Find("ChavesTexto").transform.GetComponent<TextMeshProUGUI>();
        aviso = GameObject.Find("Evento").transform.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        texto.text = "<color=yellow>Chaves Coletadas: " + coletada + "/3</color>";
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chave"))
        {
            Destroy(collision.gameObject);
            coletada++;
            aviso.text = "<color=yellow>Voc� pode abrir um ba�.</color>";
            Invoke("LimparAviso", 3);
        }
    }

    void LimparAviso()
    {
        aviso.text = "";
    }
}
