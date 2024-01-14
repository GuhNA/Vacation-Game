using UnityEngine;

public class PlayerAtk : MonoBehaviour
{    
    [SerializeField] int length;

    public bool atk;

    public int combo;

    Movement player;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<Movement>();
    }

     private void Update()
    {
        if(!atk && (Input.GetKeyDown(KeyCode.J) || (Input.GetKeyDown(KeyCode.Q))))
        {
            player.speed = 0f;
            anim.SetTrigger(""+combo);
            atk= true;
        }

    }

    public void StartCombo()
    {
        atk = false;

        if(combo < length)
        {
            combo++;
        }
    }

    public void FinishCombo()
    {
        player.speed = player.speedS;
        atk= false;
        combo = 0;
    }
}
