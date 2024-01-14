using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Image lifeBar;
    Player player;

    public Text pontuacao;


    private void Awake() {
        player = FindObjectOfType<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        lifeBar.fillAmount = (float)player.vida/100;
        pontuacao.text = "Pontuacao: " + player.pontuacao;
    }
}
