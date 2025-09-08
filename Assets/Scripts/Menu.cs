using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public TextMeshProUGUI texto;
    public void Jogar()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void SairCreditos()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Sair()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void Texto()
    {
        texto.text = "<color=white>Não</color>";
    }
}
