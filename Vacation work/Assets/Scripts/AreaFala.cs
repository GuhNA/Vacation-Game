using UnityEngine;

public class AreaFala : MonoBehaviour
{
    bool fim;
    public bool destruir;
    public string msg;
    public float tempoFala;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.GetComponent<Player>())
        {
            Falas fala = other.GetComponent<Falas>();
            fala.texto.text = msg;
            fala.timer = tempoFala;
            fim = true;

        }

        if(fim) Destroy(gameObject);
    }
}
