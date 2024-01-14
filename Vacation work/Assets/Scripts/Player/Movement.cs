using UnityEngine;

public class Movement : MonoBehaviour
{
    //Static var
    [SerializeField] float speedS_;

    GameManager game;
    public float speed;
    //bool lookRight;
    Rigidbody2D rig;

    public float speedS
    {
        set {speedS_ = value;}
        get {return speedS_;}        
    }

    private void Start() {
        speedS = speed;
    }
    private void Awake() {
        rig = GetComponent<Rigidbody2D>();
        game = FindObjectOfType<GameManager>();
    }

    void FixedUpdate()
    {
        rig.position += new Vector2(Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed,
                                     Input.GetAxisRaw("Vertical") * Time.deltaTime * speed);

    }
    private void Update() {
        if(!game.paused)
        {
            if(Input.GetAxisRaw("Horizontal") == 1) transform.eulerAngles = new Vector2(0,0);
            if(Input.GetAxisRaw("Horizontal") == -1) transform.eulerAngles = new Vector2(0,180);
        }

    }


    /*void virar()
    {
        if(lookRight) transform.eulerAngles = new Vector2 (0,180);
        if(!lookRight) transform.eulerAngles = new Vector2 (0,0);
        lookRight = !lookRight;

    }
     void direcaoGiro(bool input)
    {
        if(input != lookRight)
        {
            virar();
        }   
    }*/
}
