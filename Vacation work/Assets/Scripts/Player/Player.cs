using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public AudioSource aud;
    public Object obj;

    public Text text;
    int pontuacao_;
    bool f60, f40, f20;
    string msg;
    public int vida;
    Animator anim;
    Falas falas;

    public int pontuacao
    {
        set{pontuacao_ = value;}
        get{return pontuacao_;}
    }

    private void Start() {
        msg = "Fui capturado, só lembro da pancada, preciso achar um caminho!";
        falas.texto.text = msg;
        falas.timer = 2f;
        pontuacao = 0;
    }
    private void Awake() {
        anim = GetComponent<Animator>();
        falas = GetComponent<Falas>();
    }
    private void Update() {
        switch(vida)
        {
            case 60: 
                    if(!f60)
                    {
                        msg = "aí! Desgraçados, não param de sair!";
                        falas.texto.text = msg;
                        falas.timer = 2f;
                        f60 = true;
                    }
                break;
            case 40:
                    if(!f40)
                    {
                        msg = "Estou ficando fraco";
                        falas.texto.text = msg;
                        falas.timer = 2f;
                        f40 = true;
                    }
                break;
            case 20: 
                    if(!f20)
                    {
                        msg = "Desculpa filha, acho que não voltarei...";
                        falas.texto.text = msg;
                        falas.timer = 2f;
                        f20 = true;
                    }
                break;
            case 0: 
                anim.SetTrigger("die");                
                break;
        }

    }

    public void ChangeLife(int value)
    {
        vida= Mathf.Clamp(vida + value, 0, 200);
    }

    public void DestroyObj()
    {
        text.text = "Pontuação: " + pontuacao;
        Destroy(gameObject);
        obj.GameObject().SetActive(true);
    }

    public void deathSound()
    {
        anim.ResetTrigger("die");
        aud.Play();
    }
}
