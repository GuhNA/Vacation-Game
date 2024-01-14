using UnityEngine;

public class Enemies : MonoBehaviour
{
    float speedS;
    float cooldownS;
    int directionX;
    int directionY;
    public int life;
    public float speed;      
    public float cooldown;
    public Vector3 atkRange;

    Player player;
    bool rangeX, rangeY;
    
    public bool speedBack;
    Rigidbody2D rig;

    Animator anim;
    
    private void Awake() {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
    }

    private void Start() {
        cooldownS = cooldown;
        speedS = speed;
    }

    private void FixedUpdate() {

        if(Mathf.Abs(transform.position.x - player.transform.position.x) > atkRange.x)
        {
            rig.position += new Vector2(-1 * directionX * speed * Time.deltaTime,0);
            anim.SetInteger("select",1);
            rangeX = false;
        }
        else if(cooldown < 0) rangeX  = true;

        if(transform.position.y - player.transform.position.y < atkRange.y || 
            transform.position.y - player.transform.position.y > atkRange.z)
            {
                rig.position += new Vector2(0,-1 * directionY * speed * Time.deltaTime);
                rangeY = false;
                anim.SetInteger("select",1);
            }
        else if(cooldown < 0) rangeY = true;
    }
    void Update()
    {
        cooldown -= Time.deltaTime;

        directionX = transform.position.x > player.transform.position.x ? 1 : -1;
        directionY = transform.position.y > player.transform.position.y ? 1 : -1;
        life = Mathf.Clamp(life, 0, 100);

        if(life <= 0)
        {
            speed = 0;
            anim.SetTrigger("die");
        }

        rotation();

        if(rangeY && rangeX)
        {
            if(cooldown < 0)
            {
                anim.SetTrigger("Atk");
                speed = 0;
            }
            else
                anim.SetInteger("select", 0);
        }

        if(speedBack)
        {
            anim.ResetTrigger("Atk");
            cooldown = cooldownS;
            speed = speedS;
            speedBack = false;
        }
    }

     void rotation()
    {
        if(directionX > 0) transform.eulerAngles = new Vector2 (0,180);
        else if(directionX < 0) transform.eulerAngles = new Vector2 (0,0);
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Attack"))
        {
            life -= 25;
            anim.SetTrigger("dmg");
        }
    }

    public void Dead()
    {
        player.pontuacao++;
        Destroy(gameObject);
    }
}
