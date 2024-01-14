using UnityEngine;
using UnityEngine.SceneManagement;

public class CenaManager : MonoBehaviour
{
       public void Endgame()
    {
        Application.Quit();
    }

    public void SceneLoader(int index)
    {
        SceneManager.LoadScene(index);
    }
}
