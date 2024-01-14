using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spawn : MonoBehaviour
{
    bool activated;
    public Object enemy;
    public float timer;
    public List<Transform> spawns;
    public List<Vector3Int> tiles;

    public Tilemap tile;
    public List<TileBase> sprite;

    public HUD hud;
    int i = 0;
    
    private void Start() {
        StartCoroutine(Generate());

    }
    IEnumerator Generate()
    {
        while(true)
        {
            if(activated)
            {
                Instantiate(enemy, spawns[i]);
                if(i < spawns.Count-1) i++;
                else i = 0;
            }
            yield return new WaitForSeconds(timer);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            activated = true;
            tile.SetTiles(tiles.ToArray(), sprite.ToArray());
            hud.pontuacao.enabled = true;
        }
    }
}
