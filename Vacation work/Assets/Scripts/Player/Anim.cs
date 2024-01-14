using UnityEngine;

public class Anim : MonoBehaviour
{
    GameManager game;
    Animator anim;
    Movement player;        
    void Awake()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<Movement>();
        game = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!game.paused)
        {
            OnMove();
        }
    }

    void OnMove()
    {
        if((Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1 || Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1) && player.speed != 0)
        {
            anim.SetInteger("select",1);
        }
        else
        {
            anim.SetInteger("select",0);
        }
    }
}
