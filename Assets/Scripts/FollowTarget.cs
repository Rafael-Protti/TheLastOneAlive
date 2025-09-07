using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 5, -10);
    public float suavidade = 5;
    void Start()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player").transform;
        }
    }
    void LateUpdate()
    {
        Vector3 novaPosicao = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, novaPosicao, suavidade * Time.deltaTime);
    }
}
