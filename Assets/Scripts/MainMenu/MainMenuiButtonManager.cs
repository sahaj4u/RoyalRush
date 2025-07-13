using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonmanager : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
        
}
