using UnityEngine;

public class DetectaPlayer : MonoBehaviour
{
    public GameObject inimigo;
    MoveInimigo mover;

    private void Start()
    {
        mover = inimigo.GetComponent<MoveInimigo>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            mover.player_visto = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        mover.player_visto = false;
    }
}
