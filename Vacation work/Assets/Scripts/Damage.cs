using UnityEngine;

public class Damage : MonoBehaviour
{
    public int p1e2;
    private void OnTriggerEnter2D(Collider2D other) {
        if(p1e2 == 1)
            if(other.CompareTag("Player")) other.GetComponent<Player>().ChangeLife(-20);
        else if(p1e2 == 2)
            if(other.CompareTag("Enemy")) other.GetComponent<Player>().ChangeLife(-25);
    }
}
