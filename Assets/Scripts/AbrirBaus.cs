using TMPro;
using UnityEngine;

public class AbrirBaus : MonoBehaviour
{
    public GameObject grade;
    public int chavesnecessarias = 0;
    int baus = 0;
    TextMeshProUGUI texto;
    Animator abrefecha;
    void Start()
    {
        texto = GameObject.Find("BausTexto").transform.GetComponent<TextMeshProUGUI>();
        abrefecha = transform.GetComponent<Animator>();
    }

    
    void Update()
    {
        texto.text = "<color=yellow>Baús: " + baus + "/3</color>";
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !abrefecha.GetBool("aberto") && ColetarChaves.coletada >= chavesnecessarias)
        {
            abrefecha.SetBool("aberto", true);
            baus++;
            Destroy(grade);
        }
    }
}
