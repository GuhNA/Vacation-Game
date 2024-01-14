using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool paused_;


    public bool paused
    {
        set{paused_ = value;}
        get{return paused_;}
    }

    public Object pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!paused)
            {
                
                Time.timeScale = 0;
                pauseMenu.GameObject().SetActive(true);
                paused = true;
            }
            else 
            {
                Time.timeScale = 1;
                pauseMenu.GameObject().SetActive(false);
                paused = false;
            }
        }

    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.GameObject().SetActive(false);
        paused = false;
    }
}
