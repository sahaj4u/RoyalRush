using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public float TimeScale;
  public void OpenpauseMenu()
    {
        TimeScale = Time.timeScale;
        Time.timeScale = 0f;
    }

    public void ClosepauseMenu() 
    { 
        Time.timeScale = TimeScale;
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
