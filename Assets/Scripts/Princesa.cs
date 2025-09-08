using TMPro;
using UnityEngine;

public class Princesa : MonoBehaviour
{
    TextMeshProUGUI texto;
    void Start()
    {
        texto = GameObject.Find("Objetivo").transform.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (AbrirBaus.baus >= 3)
        {
            texto.text = "Você conseguiu me salvar!";
        }
    }
}
